using System.Collections.Generic;
using Mirror;
using Mirror.RemoteCalls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReviewsManager : NetworkBehaviour
{
	public float overallRating;

	public float decorPoints;

	public float hygienePenalty;

	public float stockPenalty;

	public TextMeshProUGUI decorText;

	public TextMeshProUGUI hygieneText;

	public TextMeshProUGUI stockText;

	public TextMeshProUGUI starText;

	public TextMeshProUGUI starText_;

	public TextMeshProUGUI starText__;

	public TextMeshProUGUI recommendedDecorText;

	public Slider decorBar;

	public Slider hygieneBar;

	public Slider stockBar;

	public Image decorBarImage;

	public Image hygieneBarImage;

	public Image stockBarImage;

	public Color green;

	public Color yellow;

	public Color red;

	public List<SpriteRenderer> emotionSprites;

	public Sprite happySprite;

	public Sprite midDecorSprite;

	public Sprite angryDecorSprite;

	public Sprite midHygieneSprite;

	public Sprite angryHygieneSprite;

	public Sprite midStockSprite;

	public Sprite angryStockSprite;

	public GameObject reviewsTab;

	public GameObject reviewsTabNotif;

	private float lowestVal = 1f;

	private string lowestRating;

	public Transform reviewHolder;

	public GameObject reviewObj;

	public static ReviewsManager Instance { get; private set; }

	private void OnEnable()
	{
		Invoke("UpdateReviewUI", 3f);
	}

	public void UpdateDecorPoints(int change)
	{
		decorPoints += change;
		CancelInvoke("UpdateReviewUI");
		Invoke("UpdateReviewUI", 0.5f);
	}

	public void UpdateHygienePenalty(int change)
	{
		hygienePenalty += change;
		CancelInvoke("UpdateReviewUI");
		Invoke("UpdateReviewUI", 0.5f);
	}

	public void UpdateStockPenalty(int change)
	{
		if (base.isServer)
		{
			stockPenalty += change;
			UpdateStockPenaltyRpc(stockPenalty);
			CancelInvoke("UpdateReviewUI");
			Invoke("UpdateReviewUI", 0.5f);
		}
	}

	[ClientRpc]
	public void UpdateStockPenaltyRpc(float newStockPenalty)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(newStockPenalty);
		SendRPCInternal("System.Void ReviewsManager::UpdateStockPenaltyRpc(System.Single)", 1361778403, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void UpdateReviewUI()
	{
		float value = 100f - hygienePenalty;
		value = Mathf.Clamp(value, 0f, 100f);
		hygieneText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		hygieneText.text = value.ToString("0") + "%";
		hygieneBar.value = value / 100f;
		float value2 = 100f - (stockPenalty + 780f);
		value2 = Mathf.Clamp(value2, 0f, 100f);
		stockText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		stockText.text = value2.ToString("0") + "%";
		stockBar.value = value2 / 100f;
		decorText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		decorText.text = decorPoints.ToString("0");
		float num = 0f;
		if (GetTargDecorPoints() > 75f)
		{
			num = GetTargDecorPoints() - 75f;
		}
		recommendedDecorText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		recommendedDecorText.text = GetTargDecorPoints().ToString();
		float num2 = decorPoints - num;
		if (num2 < 0f)
		{
			num2 = 0f;
		}
		if (GetTargDecorPoints() > 0f)
		{
			decorBar.value = num2 / GetTargDecorPoints();
		}
		else
		{
			decorBar.value = 1f;
		}
		if (CurrentDayManager.Instance.curDay == 2)
		{
			decorBar.value += 0.5f;
		}
		else if (CurrentDayManager.Instance.curDay == 3)
		{
			decorBar.value += 0.3f;
		}
		if (hygieneBar.value < 0.31f)
		{
			hygieneBarImage.color = red;
		}
		else if (hygieneBar.value < 0.61f)
		{
			hygieneBarImage.color = yellow;
		}
		else
		{
			hygieneBarImage.color = green;
		}
		if (stockBar.value < 0.31f)
		{
			stockBarImage.color = red;
		}
		else if (stockBar.value < 0.61f)
		{
			stockBarImage.color = yellow;
		}
		else
		{
			stockBarImage.color = green;
		}
		if (decorBar.value < 0.31f)
		{
			decorBarImage.color = red;
		}
		else if (decorBar.value < 0.61f)
		{
			decorBarImage.color = yellow;
		}
		else
		{
			decorBarImage.color = green;
		}
		overallRating = (decorBar.value + hygieneBar.value + stockBar.value) / 3f;
		starText.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		starText_.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		starText__.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		starText.text = (overallRating * 5f).ToString("0.0");
		starText_.text = (overallRating * 5f).ToString("0.0");
		starText__.text = (overallRating * 5f).ToString("0.0");
		lowestVal = 1f;
		if (decorBar.value < lowestVal)
		{
			lowestRating = "Decor";
			lowestVal = decorBar.value;
		}
		if (stockBar.value < lowestVal)
		{
			lowestRating = "Stock";
			lowestVal = stockBar.value;
		}
		if (hygieneBar.value < lowestVal)
		{
			lowestRating = "Hygiene";
			lowestVal = hygieneBar.value;
		}
		for (int num3 = emotionSprites.Count - 1; num3 >= 0; num3--)
		{
			SpriteRenderer spriteRenderer = emotionSprites[num3];
			if (spriteRenderer == null)
			{
				emotionSprites.RemoveAt(num3);
			}
			else if (lowestVal < 0.31f)
			{
				switch (lowestRating)
				{
				case "Decor":
					spriteRenderer.sprite = angryDecorSprite;
					break;
				case "Hygiene":
					spriteRenderer.sprite = angryHygieneSprite;
					break;
				case "Stock":
					spriteRenderer.sprite = angryStockSprite;
					break;
				}
			}
			else if (lowestVal < 0.61f)
			{
				switch (lowestRating)
				{
				case "Decor":
					spriteRenderer.sprite = midDecorSprite;
					break;
				case "Hygiene":
					spriteRenderer.sprite = midHygieneSprite;
					break;
				case "Stock":
					spriteRenderer.sprite = midStockSprite;
					break;
				}
			}
			else
			{
				spriteRenderer.sprite = null;
			}
		}
	}

	private float GetTargDecorPoints()
	{
		int curDay = CurrentDayManager.Instance.curDay;
		if (curDay < 6)
		{
			return curDay * 5 - 5;
		}
		if (curDay < 12)
		{
			curDay -= 5;
			return curDay * 10 + 20;
		}
		curDay -= 11;
		return curDay * 15 + 80;
	}

	public void GetReview()
	{
		if (base.isServer)
		{
			if (decorBarImage.color == green && stockBarImage.color == green && hygieneBarImage.color == green)
			{
				int num = Random.Range(1, 40);
				CreateReview(JSONAccess.Instance.GetMiscText("Reviews", "Perfect Review " + num));
				return;
			}
			string text = ((!(lowestVal < 0.31f)) ? "Mid" : "Bad");
			int num2 = Random.Range(1, 15);
			CreateReview(JSONAccess.Instance.GetMiscText("Reviews", text + " " + lowestRating + " Review " + num2));
		}
	}

	public void CreateReview(string reviewText)
	{
		int num = Random.Range(1, 60);
		if (num > 50)
		{
			num = 1;
		}
		string miscText = JSONAccess.Instance.GetMiscText("Reviewer Names", "Name" + num);
		int num2 = Random.Range(0, 30);
		string reviewCount_ = JSONAccess.Instance.GetMiscText("Reviewer Names", "[NUMBER] reviews").Replace("<REVIEW NUMBER>", num2.ToString());
		int num3 = Mathf.RoundToInt(overallRating * 5f);
		int num4 = Random.Range(0, 100);
		if (num4 < 20)
		{
			num3--;
		}
		else if (num4 > 80)
		{
			num3++;
		}
		num3 = Mathf.Clamp(num3, 0, 5);
		SpawnReview(miscText, reviewCount_, reviewText, num3);
	}

	[ClientRpc]
	public void SpawnReview(string name__, string reviewCount_, string reviewDesc_, int stars_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteString(name__);
		writer.WriteString(reviewCount_);
		writer.WriteString(reviewDesc_);
		writer.WriteVarInt(stars_);
		SendRPCInternal("System.Void ReviewsManager::SpawnReview(System.String,System.String,System.String,System.Int32)", 1363887677, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	public void EnforceMaxReviews()
	{
		if (reviewHolder.childCount > 10)
		{
			Object.Destroy(reviewHolder.GetChild(0).gameObject);
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_UpdateStockPenaltyRpc__Single(float newStockPenalty)
	{
		stockPenalty = newStockPenalty;
		CancelInvoke("UpdateReviewUI");
		Invoke("UpdateReviewUI", 0.5f);
	}

	protected static void InvokeUserCode_UpdateStockPenaltyRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC UpdateStockPenaltyRpc called on server.");
		}
		else
		{
			((ReviewsManager)obj).UserCode_UpdateStockPenaltyRpc__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_SpawnReview__String__String__String__Int32(string name__, string reviewCount_, string reviewDesc_, int stars_)
	{
		if (!reviewsTab.activeInHierarchy)
		{
			reviewsTabNotif.SetActive(value: true);
		}
		Review component = Object.Instantiate(reviewObj, reviewHolder).GetComponent<Review>();
		component.name_.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		component.name_.text = name__;
		component.reviewCount.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		component.reviewCount.text = reviewCount_;
		component.reviewDesc.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
		component.reviewDesc.text = reviewDesc_;
		for (int i = 0; i < stars_; i++)
		{
			component.stars[i].SetActive(value: true);
		}
		EnforceMaxReviews();
	}

	protected static void InvokeUserCode_SpawnReview__String__String__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC SpawnReview called on server.");
		}
		else
		{
			((ReviewsManager)obj).UserCode_SpawnReview__String__String__String__Int32(reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadVarInt());
		}
	}

	static ReviewsManager()
	{
		RemoteProcedureCalls.RegisterRpc(typeof(ReviewsManager), "System.Void ReviewsManager::UpdateStockPenaltyRpc(System.Single)", InvokeUserCode_UpdateStockPenaltyRpc__Single);
		RemoteProcedureCalls.RegisterRpc(typeof(ReviewsManager), "System.Void ReviewsManager::SpawnReview(System.String,System.String,System.String,System.Int32)", InvokeUserCode_SpawnReview__String__String__String__Int32);
	}
}
