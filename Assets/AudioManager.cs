using Unity.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip LevelSound;
   
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayLevelSound()
    {
        audioSource.PlayOneShot(LevelSound);
    }
   

}
