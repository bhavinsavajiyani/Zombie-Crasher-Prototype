using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public Animator cameraAnimator;
   public void PlayGame()
   {
       cameraAnimator.Play("CameraSlide animation");
   }
}
