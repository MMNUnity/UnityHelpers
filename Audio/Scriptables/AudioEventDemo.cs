using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioEvents/Demo")]
public class AudioEventDemo : AudioEvent
{
    public AudioClip[] audioClips;

    //public RangedFloat volume;
    public float volumeMin;
    public float volumeMax;
    public float pitchMin;
    public float pitchMax;

    //[MinMaxRange()]

    public override void Play(AudioSource audioSource)
    {
        if (audioClips.Length == 0) return;

        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.volume = Random.Range(volumeMin, volumeMax);
        audioSource.pitch = Random.Range(pitchMin, pitchMax);

        audioSource.Play();
    }
}
