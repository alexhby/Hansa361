﻿using UnityEngine;
using System.Collections;

public class JoinWorldMenu : MonoBehaviour
{



    public int sceneToStart = 1;                                        //Index number in build settings of scene to load

    [HideInInspector]
    public bool inMainMenu = true;                  //If true, pause button disabled in main menu (Cancel in input manager, default escape key)
    [HideInInspector]
    public Animator animColorFade;                  //Reference to animator which will fade to and from black when starting game.
    [HideInInspector]
    public Animator animMenuAlpha;                  //Reference to animator that will fade out alpha of MenuPanel canvas group
    public AnimationClip fadeColorAnimationClip;        //Animation clip fading to color (black default) when changing scenes
    [HideInInspector]
    public AnimationClip fadeAlphaAnimationClip;        //Animation clip fading out UI elements alpha


    private PlayMusic playMusic;                                        //Reference to PlayMusic script
    private float fastFadeIn = .01f;                                    //Very short fade time (10 milliseconds) to start playing music immediately without a click/glitch
    private ShowPanels showPanels;                                      //Reference to ShowPanels script on UI GameObject, to show and hide panels
                                                                        // Use this for initialization
    void Awake()
    {
        //Get a reference to ShowPanels attached to UI object
        showPanels = GetComponent<ShowPanels>();

        //Get a reference to PlayMusic attached to UI object
        playMusic = GetComponent<PlayMusic>();
    }



    public void BackButtonClicked()
    {
        //Use invoke to delay calling of LoadDelayed by half the length of fadeColorAnimationClip
        Invoke("BackLoadDelayed", fadeColorAnimationClip.length * .5f);

        //Set the trigger of Animator animColorFade to start transition to the FadeToOpaque state.
        animColorFade.SetTrigger("fade");

    }

    public void BackLoadDelayed()
    {

        //Hide the join world menu UI element
        showPanels.HideMenu(5);
        //Show the world menu
        showPanels.ShowMenu(4);
    }
}
