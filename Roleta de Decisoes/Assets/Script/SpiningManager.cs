using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;
using TMPro;

public class SpiningManager : MonoBehaviour {

	private int randVal;
	private float timeInterval;
	private bool isCoroutine;
	private int finalAngle;
	private string perg;
	public Text painel;
	public GameObject wheel;
	public Image RecRoul;
	public Text winText;
	public int section;
	public bool end;
	float totalAngle;
	private string quest;
	public int volta=0;
	public Text BeatText;
	public GameObject PanelQuest;
	public GameObject inicial;
	public GameObject arrow;
	public GameObject restart;
	public HitBoc voltas;
	//public GameObject Developer;
	public Text Contagem;
	private float wheel_posX;
	private float wheel_posY;
	private float arrow_posX;
	private float arrow_posY;
	private float placa_posX;
	private float placa_posY;
	private float quest_posX;
	private float quest_posY;
	//private float tempo = 5;
	private float dev_posX;
	private float dev_posY;

	public Button btnSpin;
	public GameObject SpinOrNot;
	public GameObject Myself;
	public int teste;
	public bool param =false;

	private void Start () {
	//	voltas.volta =0;
		isCoroutine = true;
		section=12;
		PanelQuest = GameObject.FindGameObjectWithTag("PanelQuest");
		wheel_posX = wheel.transform.position.x;
		wheel_posY = wheel.transform.position.y;
		arrow_posX = arrow.transform.position.x;
		//print("X:"+wheel_posX+"Y:"+wheel_posY);
		arrow_posY = arrow.transform.position.y;
		placa_posX = RecRoul.transform.position.x;
		placa_posY = RecRoul.transform.position.y;
		quest_posX = PanelQuest.transform.position.x;
		quest_posY = PanelQuest.transform.position.y;
		PanelQuest.SetActive(false);
		restart.SetActive(false);
		wheel.SetActive(false);
		arrow.SetActive(false);
		//RecRoul.transform.position = new Vector2(1000,1000);
		PanelQuest.SetActive(true);
		BeatText.fontSize = 25;
		BeatText.text = "Clique no botão abaixo para girar. No botão de cima, créditos ao autor. Sua pergunta aparecerá aqui.";

//		SpinOrNot.SetActive(false);

		totalAngle = 360 / section;
		//painel.SetActive(false);
		wheel.SetActive(true);	
		//SpinOrNot.SetActive(false);	
		
	/*	PanelQuest.transform.position = new Vector2(1000,1000);
		wheel.transform.position = new Vector2(1000,1000);
		RecRoul.transform.position = new Vector2(1000,1000);
		arrow.transform.position = new Vector2(1000,1000);
		restart.transform.position = new Vector2(1000,1000);*/
	}

	private void Update () {
		//if(Input.GetMouseButton(0)) Perai();

		/*if (Input.GetMouseButton (0) && isCoroutine) {
			StartCoroutine (Spin());
		}*/
		//if(!isCoroutine)
		//	restart.SetActive(true);
		if(Input.GetMouseButton(0) && isCoroutine) 
		{
			wheel.SetActive(true);
			arrow.SetActive(true);
			print("X: "+placa_posX+"  Y:"+placa_posY);
			RecRoul.transform.position = new Vector2(placa_posX,placa_posY);
			StartCoroutine(Spin());
			
			
			
		}
	}
	/*void OnMouseDown()
	{
		StartCoroutine(Spin());
	}*/
	public IEnumerator Spin() //IEnumerator
	{//AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
//		while(param == true) {wheel.SetActive(false); StopAllCoroutines();}

			isCoroutine = false;
			
			randVal = Random.Range(200, 250);//angles per round
			timeInterval = 0.001f*Time.deltaTime;
			for (int i = 0; i < randVal; i++)
			{
				transform.Rotate (0, 0, (totalAngle/3)); //Start Rotate by 30 angles
				//slow
				if (i > Mathf.RoundToInt (randVal * 0.6f))
					timeInterval = 0.5f*Time.deltaTime;

				if (i > Mathf.RoundToInt (randVal * 0.8f))
					timeInterval = 1f*Time.deltaTime;

				if (i > Mathf.RoundToInt (randVal * 1.1f))
					timeInterval = 1.5f*Time.deltaTime;

				if (i > Mathf.RoundToInt (randVal * 1.1f))
					timeInterval = 2f*Time.deltaTime;

				if (i > Mathf.RoundToInt (randVal * 1.3f))
					timeInterval = 2.5f*Time.deltaTime;

				yield return new WaitForSeconds (timeInterval);
				//finish spinning
			}
			teste++;
			btnSpin.transform.position = new Vector2(1000,1000);
			if (Mathf.RoundToInt (transform.eulerAngles.z) % totalAngle != 0) //when the indicator stop between 2 numbers,it will add aditional step 
				transform.Rotate (0, 0, totalAngle/2);
			
			finalAngle = Mathf.RoundToInt (transform.eulerAngles.z);//round off euler angle of wheel value
			float aux = finalAngle;
			quest = VerAng(aux);
			BeatText.text = "Pergunta "+quest;
			restart.SetActive(true);
			StopAllCoroutines();
			//////////////////////////////////////////////////
				//VERIFICAÇÃO DE ANGULO//
			
			print("Angle: "+aux);
			//quest = VerAng(aux);
		
			//PanelQuest.SetActive(true);
			

			print("oi");
		//	StopCoroutine(Spin());
		//	yield return 0;
		//	ReturnAngle(aux,teste);
			
			
			//quest = VerAng(anguloreal);
			
			
			isCoroutine = true;
			//voltas.volta =0;
		/*	StopCoroutine(Spin());
			quest = VerAng(finalAngle);
			BeatText.text = "Pergunta: "+quest;*/

	}//Spin
	private void ReturnAngle(float aux,int teste)
	{
		float aux2;
		if(teste == 1)
		{
			aux2 = aux;
			//return aux2;
			string quest2 = VerAng(aux2);
			BeatText.text = "Pergunta "+quest2;
		}
	}
	public void Creditos()
	{
		StopAllCoroutines();
		SceneManager.LoadScene("Creditos");	
		GameObject.Find("Myself").transform.position =  new Vector3 ( (Screen.width * 50) / 100, Screen.height * 90 / 100 , 10 ) ;
	}
	public void voltaRoleta()
	{
		SceneManager.LoadScene("Roleta");
		btnSpin.transform.position = new Vector2(1000,1000);
		restart.SetActive(true);
	}
	private string VerAng(float aux)
	{
		//3,5,7,10 -> verde
		//1,6,8,11 -> azul
		//2,4,9,12 -> vermelho
		print("Aux em verAng: "+aux);
		perg="";
		if(aux >0  && aux <30)
			perg = "1: Nasceu meu bebê. Como conciliar a escola com as responsabilidades de ser pai / mãe (pais)?";//1				
		if(aux > 30  && aux <60)
			perg = "2: Minha família não aceitou minha gravidez. O que fazer?";//2			 		
		if(aux > 60  && aux <90)		
			perg = "3: Meu corpo ainda não se desenvolveu tanto quanto dos meus amigos. O que fazer?";//3		 		
		if(aux > 90  && aux <120)		
			perg = "4: Fiquei grávida / engravidei alguém. E agora?";//4			 		
		if(aux > 120  && aux < 150)		
			perg = "5: Meu corpo está se desenvolvendo rápido. E agora?";//5
		if(aux > 150  && aux < 180)		
			perg = "6: Como lidar com a responsabilidade de cuidar de um bebê?";//6	 		
		if(aux > 180  && aux < 210)		
			perg = "7: Ouvi comentários sobre meu corpo na rua. Qual reação tomar?";//7		 		
		if(aux > 210  && aux < 240)		
			perg = "8: Depois da gravidez meu corpo não voltou ao que era antes. Como lidar?";//8		 		
		if(aux > 240  && aux < 270)		
			perg = "9: A gravidez está mudando meu corpo. Será que continuarei a desejar e ser desejada?";//9		 		
		if(aux > 270  && aux < 300)		
			perg = "10: Perdi a virgindade. Como contar aos meus pais?";//10
		if(aux > 300  && aux < 330)		
			perg = "11: Não tenho condições financeiras, nem me sinto amadurecida (o) para cuidar do bebê! O que fazer?";//11			 		
		if(aux > 330  && aux < 360)
			perg = "12: Meu (minha) parceiro (a) quer abortar. E agora?";//12		
		switch(aux)
		{
			case 0f:
				perg="1: Nasceu meu bebê. Como conciliar a escola com as responsabilidades de ser pai / mãe (pais)?";
				//perg="Meu(minha) parceiro(a) quer abortar. E agora?";
				//StopAllCoroutines();
				//StartCoroutine(Spin());
				break;
			case 30f:
				perg="1: Nasceu meu bebê. Como conciliar a escola com as responsabilidades de ser pai / mãe (pais)?";
				break;
			case 60f:
				perg="2: Minha família não aceitou minha gravidez. O que fazer?";
				break;			
			case 90f:
				perg="3: Meu corpo ainda não se desenvolveu tanto quanto dos meus amigos. O que fazer?";
				break;
			case 120f:
				perg="4: Fiquei grávida / engravidei alguém. E agora?";
				break;
			case 150f:
				perg="5: Meu corpo está se desenvolvendo rápido. E agora?";
				break;
			case 180f:
				perg="6: Como lidar com a responsabilidade de cuidar de um bebê?";
				break;
			case 210f:
				perg="7: Ouvi comentários sobre meu corpo na rua. Qual reação tomar?";
				break;
			case 240f:
				perg="8: Depois da gravidez meu corpo não voltou ao que era antes. Como lidar?";
				break;
			case 270f:
				perg="9: A gravidez está mudando meu corpo. Será que continuarei a desejar e ser desejada?";
				break;
			case 300f:
				perg="10: Perdi a virgindade. Como contar aos meus pais?";
				break;
			case 330f:
				perg="11: Não tenho condições financeiras, nem me sinto amadurecida (o) para cuidar do bebê! O que fazer?";
				break;
			case 360f:
				perg="12: Meu (minha) parceiro (a) quer abortar. E agora?";
				break;
		}
		print("Aux em verAngFinal: "+aux);
		return perg;
	}
	public void desactiveGO()
	{
		wheel.gameObject.SetActive(true);
		BeatText.gameObject.SetActive(false);
		//volta=0;
		BeatText.text = "";
		PanelQuest.SetActive(false);
	}
	public void trocaPanel()
	{	
		//StopAllCoroutines();	
		wheel.SetActive(true);
		arrow.SetActive(true);
		RecRoul.transform.position = new Vector2(placa_posX,placa_posY);
		//wheel.SetActive(true);
		//isCoroutine=false;
		StartCoroutine(Spin());
		//teste=0;
	}
	public void ToDeSaida()
	{
		Thread.Sleep(2000);
		
		Application.Quit();
	}

	public void TheDev()
	{
		arrow.SetActive(false);

		//RecRoul.transform.position = new Vector2(1000,1000);

		wheel.SetActive(false);
		
		/*dev_posX = Developer.transform.position.x;
		dev_posY = Developer.transform.position.y;
		Developer.transform.position = new Vector2(wheel_posX+2.8f,wheel_posY);
		*/
		
		
		//Thread.Sleep(1000);
		/*Developer.transform.position = new Vector2(1000,1000);
		wheel.SetActive(true);
		arrow.SetActive(true);
		RecRoul.transform.position = new Vector2(placa_posX,placa_posY);*/
		//isCoroutine=false;	
	}
	public void NotTheDev()
	{
		//param = false;
		//Developer.transform.position = new Vector2(dev_posX,dev_posY);
		wheel.SetActive(true);
		arrow.SetActive(true);
		//RecRoul.transform.position = new Vector2(placa_posX,placa_posY);
		BeatText.fontSize = 25;
		BeatText.text = "Clique no botão de baixo para girar. No botão da esquerda, créditos ao autor. Sua pergunta aparecerá aqui.";

	}
	public void ExitWheel()
	{
		/*wheel.SetActive(false);
		arrow.SetActive(false);*/
		//Developer.SetActive(false);
		wheel.SetActive(false);
		//Myself.SetActive(false);
		print("Quitei");	
		Application.Quit();
	}
	public void ExitDev()
	{
		/*wheel.SetActive(false);
		arrow.SetActive(false);*/
		//Developer.SetActive(false);
		//wheel.SetActive(false);
		Myself.SetActive(false);
		print("QuiteiDoDev");	
		Application.Quit();
	}
	public void LimpaCampo()
	{
		//isCoroutine = true;
		RecRoul.transform.position = new Vector2(placa_posX,placa_posY);
		//SetText("");
		if(Input.GetMouseButton(0) && isCoroutine) 
		{
			StartCoroutine(Spin());
			teste=0;
		}
	}
}
