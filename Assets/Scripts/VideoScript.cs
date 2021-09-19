using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    public VideoPlayer Bg;
    // Start is called before the first frame update
    void Awake()
    {
        Bg = GetComponent<VideoPlayer>();
        Bg.url = System.IO.Path.Combine(Application.streamingAssetsPath, "Bg.mp4");
        Bg.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
