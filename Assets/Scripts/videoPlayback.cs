using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class videoPlayback : MonoBehaviour
{

    public RawImage image;

    public VideoClip videoToPlay;

    private VideoPlayer videoPlayer;
    private VideoSource videoSource;


    // Use this for initialization
    void Start()
    {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
    }

    IEnumerator playVideo()
    {

        //Add VideoPlayer to the GameObject
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        videoPlayer.source = VideoSource.VideoClip;

        
        videoPlayer.clip = videoToPlay;
        videoPlayer.Prepare();

        //Wait until video is prepared
        WaitForSeconds waitTime = new WaitForSeconds(0.5f);
        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");

            yield return waitTime;

            break;
        }

        image.texture = videoPlayer.texture;

        videoPlayer.isLooping=true;

        //Play Video
        videoPlayer.Play();


    }
}