using UnityEngine.UI;
using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public int playerLevel = 0;
    public Text levelText;
    public AudioManager aud;

    [ContextMenu("Increase Score")]
    public void addLevel()
    {
        if (aud != null)
            aud.PlayLevelSound();

        playerLevel++;
        levelText.text = playerLevel.ToString();
    }
}
