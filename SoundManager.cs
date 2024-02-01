using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        // Ensure that there's only one instance of the SoundManager in the scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent SoundManager from being destroyed when reloading the scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(string soundName)
    {
        // Load the clip from the Resources/Audio folder
        AudioClip clip = Resources.Load<AudioClip>($"Audio/{soundName}");
        if (clip != null)
        {
            // Create a temporary GameObject to play the clip
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(clip);

            // Destroy the GameObject after the clip is done playing
            Destroy(soundGameObject, clip.length);
        }
        else
        {
            Debug.LogWarning($"SoundManager: Audio clip not found for name {soundName}");
        }
    }
}