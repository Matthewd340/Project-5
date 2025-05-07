using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = musicSource.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }
}
