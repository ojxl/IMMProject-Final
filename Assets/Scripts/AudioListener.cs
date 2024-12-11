using UnityEngine;

public class EnsureSingleAudioListener : MonoBehaviour
{
    void Awake()
    {
        // Find all active Audio Listeners in the scene
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();

        // Keep the first Audio Listener and disable the rest
        for (int i = 1; i < listeners.Length; i++)
        {
            listeners[i].enabled = false;
        }
    }
}
