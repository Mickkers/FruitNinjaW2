using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource hitSfx;
    [SerializeField] private AudioSource explodeSfx;

    // Start is called before the first frame update
    void Start()
    {
        if (AudioController.Instance is null)
        {
            return;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void SlashSFX()
    {
        hitSfx.Play();
    }

    public void ExplodeSFX()
    {
        explodeSfx.Play();
    }
}
