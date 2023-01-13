using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playButton, gameOverScreen;

    [SerializeField] ParticleSystem particle;

    internal bool isMoving;

    public void PlayButton()
    {
        StartCoroutine("PlayButtonRoutine");
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator PlayButtonRoutine()
    {
        DOTween(playButton, 0f, .5f);
        yield return new WaitForSeconds(.6f);
        playButton.SetActive(false);
        isMoving = true;
        particle.Play();
    }

    internal void GameOver(bool won)
    {
        if (won)
            CallGameOverScreen("You Won!");
        else
            CallGameOverScreen("You Lost!");
    }

    private void CallGameOverScreen(string status)
    {
        UIManager.instance.WinOrLoseText(status);
        isMoving = false;
        UIManager.instance.GameOverDiamondText();
        gameOverScreen.SetActive(true);
        DOTween(gameOverScreen, 1f, .5f);
        particle.Stop();
    }

    void DOTween(GameObject panel, float value, float time)
    {
        panel.GetComponent<RectTransform>().DOScale(value, time);
        panel.GetComponent<CanvasGroup>().DOFade(value, time);
    }
}
