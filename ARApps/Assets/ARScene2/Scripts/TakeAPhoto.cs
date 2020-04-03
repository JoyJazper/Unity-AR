/*using System.IO;
using UnityEngine;

public class TakeAPhoto : MonoBehaviour
{
    public int fileCounter;

    //private Camera _camera;

    public Camera MainCamera;
    
    void start()
    {
        fileCounter = 1;
    }

    public void Capture()
    {

        Debug.Log(MainCamera);
        
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = MainCamera.targetTexture;

        Debug.Log(MainCamera.targetTexture.width);

        Texture2D image = new Texture2D(MainCamera.targetTexture.width, MainCamera.targetTexture.height, TextureFormat.RGB24, false);
        image.ReadPixels(new Rect(0, 0, MainCamera.targetTexture.width, MainCamera.targetTexture.height), 0, 0, false);
        image.Apply();
        //RenderTexture.active = activeRenderTexture;

        byte[] bytes = image.EncodeToJPG();

        string filename = Application.dataPath + "KoronaPic" + fileCounter;
        //File.WriteAllBytes(Application.persistentDataPath + "/Backgrounds/" + "KaronaSelfie" +fileCounter + ".png", bytes);
        System.IO.File.WriteAllBytes(filename, bytes);
        fileCounter++;
    }
}
*/
/*
using System.IO;
using UnityEngine;
using System.Collections;
 
public class TakeAPhoto : MonoBehaviour
{

    public delegate void ScreenReadyEventDelegate();

    public event ScreenReadyEventDelegate ScreenReadyEvent;

    public Texture2D screenshot { get; private set; }

    private bool capturing = false;

    private Rect captureRect;

    private int oldAntiAliasingSettings;

    private int noAACountdown;

    public Camera MainCamera;

    public int fileCounter;

    public void TakeScreenshot()
    {
        oldAntiAliasingSettings = QualitySettings.antiAliasing;
        QualitySettings.antiAliasing = 0;
        captureRect = new Rect(0, 0, Screen.width, Screen.height);
        noAACountdown = 2;
        capturing = true;
    }

    void start()
    {
        fileCounter = 1;
    }

    public void OnPostRender()
    {
        if (capturing)
        {
            noAACountdown--;
            if (noAACountdown > 0)
                return;

            screenshot = new Texture2D(Mathf.RoundToInt(captureRect.width), Mathf.RoundToInt(captureRect.height), TextureFormat.ARGB32, false);
            screenshot.ReadPixels(captureRect, 0, 0, false);
            screenshot.Apply();

            



            byte[] bytes = screenshot.EncodeToJPG();
            File.WriteAllBytes(Application.persistentDataPath + "/Backgrounds/" + "KaronaSelfie" + fileCounter + ".jpg", bytes);
            fileCounter++;


            capturing = false;


            QualitySettings.antiAliasing = oldAntiAliasingSettings;

            if (ScreenReadyEvent != null)
                ScreenReadyEvent();
        }
    }

}
*/
/*
using UnityEditor;
using UnityEngine;
using System.Collections;

public class TakeAPhoto : MonoBehaviour
{
    public int resWidth = 2550;
    public int resHeight = 3300;

    private bool takeHiResShot = false;

    public static string ScreenShotName(int width, int height)
    {
        return string.Format("screen_{1}x{2}_{3}.png",
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    public void TakeHiResShot()
    {
        takeHiResShot = true;
    }

    void LateUpdate()
    {
        takeHiResShot |= Input.GetKeyDown("k");
        if (takeHiResShot)
        {
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            GetComponent<Camera>().targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            GetComponent<Camera>().Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            GetComponent<Camera>().targetTexture = null;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);
            byte[] bytes = screenShot.EncodeToPNG();
            string filename = EditorUtility.SaveFilePanel(
            "Save texture as PNG",
            "",
            "test" + ".png",
            "png");

            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeHiResShot = false;
        }
        takeHiResShot = false;
    }

    protected string m_textPath;

    protected FileBrowser m_fileBrowser;

    [SerializeField]
    protected Texture2D m_directoryImage,
                        m_fileImage;

    protected void OnButtonClick()
    {
        if (m_fileBrowser != null)
        {
            m_fileBrowser.OnGUI();
        }
        else
        {
            OnGUIMain();
        }
    }

    protected void OnGUIMain()
    {

        GUILayout.BeginHorizontal();
        GUILayout.Label("Path", GUILayout.Width(100));
        GUILayout.FlexibleSpace();
        GUILayout.Label(m_textPath ?? "none selected");
        if (GUILayout.Button("...", GUILayout.ExpandWidth(false)))
        {
            m_fileBrowser = new FileBrowser(
                new Rect(100, 100, 600, 500),
                "Choose Location",
                FileSelectedCallback
            );
            //m_fileBrowser.SelectionPattern = "*.txt";
            m_fileBrowser.DirectoryImage = m_directoryImage;
            m_fileBrowser.FileImage = m_fileImage;
        }
        GUILayout.EndHorizontal();
    }

    protected void FileSelectedCallback(string path)
    {
        m_fileBrowser = null;
        string m_Path = path;
    }
}
*/