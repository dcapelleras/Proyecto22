using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SfxSource;
    AudioMixerGroup musicGroup;
    AudioMixerGroup sfxGroup;
    public List<AudioClip> musicClips= new List<AudioClip>();
    public List<AudioClip> soundClips = new List<AudioClip>();

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        //musicSource.outputAudioMixerGroup = musicGroup;
        //SfxSource.outputAudioMixerGroup = sfxGroup;
    }

    public void ChangeMusic(int clipIndex)
    {
        if (musicSource.clip == musicClips[clipIndex] || musicClips[clipIndex] == null)
        {
            return;
        }
        musicSource.clip = musicClips[clipIndex];

        musicSource.Play();
    }

    public void PlaySound(int clipIndex)
    {
        if (soundClips[clipIndex] == null)
        {
            return;
        }

        SfxSource.PlayOneShot(soundClips[clipIndex]);
    }
}
