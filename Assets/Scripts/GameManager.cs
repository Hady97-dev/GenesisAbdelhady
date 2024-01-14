using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject FadeInImage;
    public GameObject Man;
    public GameObject WakeUpButton;

    public TMP_Text CurrentBallance;
    public TMP_Text CurrentBallance0;
    public int BallanceValue;

    public TMP_Text BankBallance;
    public int BankBallanceValue;

    public GameObject[] ManInventory;
    public GameObject[] FirstShopKpsInventoryBuy;
    public GameObject[] FirstShopKpsInventorySell;
    public GameObject[] SecondShopKpsInventoryBuy;
    public GameObject[] SecondShopKpsInventorySell;

    public GameObject ManPos;
    public Movement3D movement3D;

    public TMP_InputField AmountInput;
    private int Amount;





    // Start is called before the first frame update
    void Start()
    {
        CurrentBallance.text = BallanceValue.ToString("");
        CurrentBallance0.text = BallanceValue.ToString("");
        

        BankBallance.text = BankBallanceValue.ToString("");
        BankBallanceValue = 3000;

        Amount = int.Parse(AmountInput.text);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentBallance.text = BallanceValue.ToString("");
        CurrentBallance0.text = BallanceValue.ToString("");

        Amount = int.Parse(AmountInput.text);

        BankBallance.text = BankBallanceValue.ToString("");
        
    }

    public void WakeUpBtn()
    {
        FadeInImage.SetActive(false);
        WakeUpButton.SetActive(false);
        movement3D.anim.SetBool("IsLaying", false);
        Man.transform.position =Vector3.MoveTowards( Man.transform.position,ManPos.transform.position,100f);
        Man.transform.RotateAround(Man.transform.position, Vector3.up, -180);
        movement3D.canvas.gameObject.SetActive(true);


        BankBallanceValue = (int)((1.1) * BankBallanceValue);
        PlayerPrefs.SetInt("BankBallanceValue", BankBallanceValue);
      //  SceneManager.LoadScene("SampleScene");


    }

    public void DepositButon()
    {
        
        if (BallanceValue - Amount >= 0)
        {
            BankBallanceValue += Amount;
            BallanceValue -= Amount;
        }
        else if (BallanceValue - Amount <= 0)
        {
            Debug.Log("no money");
           // BankBallanceValue -= Amount;
           // BallanceValue += Amount;
        }
            
        
    }
    public void WithdrawButon()
    {
        
        if (BankBallanceValue - Amount >= 0)
        {
            BankBallanceValue -= Amount;
            BallanceValue += Amount;
        }
        else if (BankBallanceValue - Amount <= 0)
        {
            Debug.Log("no money");
           // BankBallanceValue += Amount;
           // BallanceValue -= Amount;
        }
            
        

    }



    public void AppleBuy()
    {
        ManInventory[0].gameObject.SetActive(true);
        FirstShopKpsInventoryBuy[0].gameObject.SetActive(false);
        FirstShopKpsInventorySell[0].gameObject.SetActive(true);
        BallanceValue -= 30;
    }
    public void TomatoBuy()
    {
        ManInventory[1].gameObject.SetActive(true);
        FirstShopKpsInventoryBuy[1].gameObject.SetActive(false);
        FirstShopKpsInventorySell[1].gameObject.SetActive(true);
        BallanceValue -= 15;
    }
    public void BananaBuy()
    {
        ManInventory[2].gameObject.SetActive(true);
        FirstShopKpsInventoryBuy[2].gameObject.SetActive(false);
        FirstShopKpsInventorySell[2].gameObject.SetActive(true);
        BallanceValue -= 25;
    }

    public void AppleSell()
    {
        ManInventory[0].gameObject.SetActive(false);
        FirstShopKpsInventoryBuy[0].gameObject.SetActive(true);
        FirstShopKpsInventorySell[0].gameObject.SetActive(false);
        BallanceValue += 30;
    }
    public void TomatoSell()
    {
        ManInventory[1].gameObject.SetActive(false);
        FirstShopKpsInventoryBuy[1].gameObject.SetActive(true);
        FirstShopKpsInventorySell[1].gameObject.SetActive(false);
        BallanceValue += 15;
    }
    public void BananaSell()
    {
        ManInventory[2].gameObject.SetActive(false);
        FirstShopKpsInventoryBuy[2].gameObject.SetActive(true);
        FirstShopKpsInventorySell[2].gameObject.SetActive(false);
        BallanceValue += 25;
    }




    public void CofeeBuy()
    {
        ManInventory[3].gameObject.SetActive(true);
        SecondShopKpsInventoryBuy[0].gameObject.SetActive(false);
        SecondShopKpsInventorySell[0].gameObject.SetActive(true);
        BallanceValue -= 10;
    }
    public void ColdDrinkBuy()
    {
        ManInventory[4].gameObject.SetActive(true);
        SecondShopKpsInventoryBuy[1].gameObject.SetActive(false);
        SecondShopKpsInventorySell[1].gameObject.SetActive(true);
        BallanceValue -= 15;
    }
    public void PepsiBuy()
    {
        ManInventory[5].gameObject.SetActive(true);
        SecondShopKpsInventoryBuy[2].gameObject.SetActive(false);
        SecondShopKpsInventorySell[2].gameObject.SetActive(true);
        BallanceValue -= 20;
    }

    public void CofeeSell()
    {
        ManInventory[3].gameObject.SetActive(false);
        SecondShopKpsInventoryBuy[0].gameObject.SetActive(true);
        SecondShopKpsInventorySell[0].gameObject.SetActive(false);
        BallanceValue += 10;
    }
    public void ColdDrinkSell()
    {
        ManInventory[4].gameObject.SetActive(false);
        SecondShopKpsInventoryBuy[1].gameObject.SetActive(true);
        SecondShopKpsInventorySell[1].gameObject.SetActive(false);
        BallanceValue += 15;
    }
    public void PepsiSell()
    {
        ManInventory[5].gameObject.SetActive(false);
        SecondShopKpsInventoryBuy[2].gameObject.SetActive(true);
        SecondShopKpsInventorySell[2].gameObject.SetActive(false);
        BallanceValue += 20;
    }

}
