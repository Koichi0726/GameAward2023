using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionSelect : MonoBehaviour
{
    private Image BGMImage;
    private Text BGMText;
    private Image SEImage;
    private Text SEText;
    private Image ReadMeImage;
    private Text ReadMeText;
    private Image BackImage;
    private Text BackText;


    [SerializeReference] GameObject GameScreen;
    [SerializeReference] GameObject OptionScreen;
    [SerializeReference] GameObject kari;

    [SerializeReference] AudioMixerSnapshot BGM;
    

    public Slider bgmSlider;         // Sliderを格納する変数
    public Slider SESlider;          // SEを格納する変数
    public AudioSource BGMSource;    // BGMを再生するAudioSourceを格納する変数
    public AudioSource SESourse;     // SE再生するAudioSourceを格納する変数

    //public AudioMixerSnapshot BGM;

    private int SelectOptionNum; 

    // Start is called before the first frame update
    void Start()
    {
        BGMImage = GameObject.Find("BGMImage").GetComponent<Image>();
        BGMText = GameObject.Find("BGM").GetComponent<Text>();
        SEImage = GameObject.Find("SEImage").GetComponent<Image>();
        SEText = GameObject.Find("SE").GetComponent<Text>();
        ReadMeImage = GameObject.Find("ReadMeImage").GetComponent<Image>();
        ReadMeText = GameObject.Find("ReadMe").GetComponent<Text>();
        BackImage = GameObject.Find("BackImage").GetComponent<Image>();
        BackText = GameObject.Find("Back").GetComponent<Text>();

        BGMImage.color = new Color(0, 0, 0, 255);
        BGMText.color = new Color(255, 255, 255, 255);

        bgmSlider.value = 5.0f;
        SESlider.value = 5.0f;

        SelectOptionNum = 0;
    }

    // Update is called once per frame
    void Update()
    {    
        //選択
        SelectOptionNum -= AxisInput.GetAxisRawRepeat("Vertical_PadX");

        if (SelectOptionNum == -1)
        {
            SelectOptionNum = 3;
        }
        if (SelectOptionNum == 4)
        {
            SelectOptionNum = 3;
            SelectOptionNum = SelectOptionNum % 3;
        }


        switch (SelectOptionNum)
        {
            case 0:
                //色変更
                BGMImage.color = new Color(0, 0, 0, 255);
                BGMText.color = new Color(255, 256, 256, 255);

                SEImage.color = new Color(255, 255, 255, 255);
                SEText.color = new Color(0, 0, 0, 255);
                ReadMeImage.color = new Color(255, 256, 256, 255);
                ReadMeText.color = new Color(0, 0, 0, 255);
                BackImage.color = new Color(255, 255, 255, 255);
                BackText.color = new Color(0, 0, 0, 255);
              
                bgmSlider.value += AxisInput.GetAxisRawRepeat("Horizontal_PadX") * 5.0f;

                // Sliderの値をAudioSourceの音量に反映する
                //BGM.audioMixer.SetFloat("BGM", bgmSlider.value);

                break;

            case 1:
                SEImage.color = new Color(0, 0, 0, 255);
                SEText.color = new Color(255, 255, 255, 255);

                BGMImage.color = new Color(255, 255, 255, 255);
                BGMText.color = new Color(0, 0, 0, 255);
                ReadMeImage.color = new Color(255, 256, 256, 255);
                ReadMeText.color = new Color(0, 0, 0, 255);
                BackImage.color = new Color(255, 255, 255, 255);
                BackText.color = new Color(0, 0, 0, 255);

                SESlider.value += AxisInput.GetAxisRawRepeat("Horizontal_PadX") * 5.0f;

                // Sliderの値をAudioSourceの音量に反映する
                //SESourse.volume = SESlider.value;

                break;

            case 2:
                ReadMeImage.color = new Color(0, 0, 0, 255);
                ReadMeText.color = new Color(255, 255, 255, 255);

                BGMImage.color = new Color(255, 255, 255, 255);
                BGMText.color = new Color(0, 0, 0, 255);
                SEImage.color = new Color(255, 255, 255, 255);
                SEText.color = new Color(0, 0, 0, 255);
                BackImage.color = new Color(255, 255, 255, 255);
                BackText.color = new Color(0, 0, 0, 255);
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    Application.Quit();
                }
                break;
            case 3:
                BackImage.color = new Color(0, 0, 0, 255);
                BackText.color = new Color(255, 255, 255, 255);

                BGMImage.color = new Color(255, 255, 255, 255);
                BGMText.color = new Color(0, 0, 0, 255);
                SEImage.color = new Color(255, 255, 255, 255);
                SEText.color = new Color(0, 0, 0, 255);
                ReadMeImage.color = new Color(255, 256, 256, 255);
                ReadMeText.color = new Color(0, 0, 0, 255);

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    GameScreen.SetActive(true);
                    OptionScreen.SetActive(false);
                    kari.SetActive(true);
                }
                break;                
        }

        
        
    }

    public void SetBGM(float volume)
    {
        BGM.audioMixer.SetFloat("BGM", volume);
        Debug.Log(volume);
    }

    public void SetSE(float volume)
    {
        BGM.audioMixer.SetFloat("SE", volume);
    }
}
