using I2.Loc;
using TMPro;
using UnityEngine;

public class NodeInteractionUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private OreNodeHealthbar healthbar;

	[Header("Runtime")]
	private T_Item currentTarget;

	private int currentPieceIndex = -1;

	private int lastKnownHealth = -1;

	private void Start()
	{
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
	}

	private void Update()
	{
		if (currentTarget == null || !currentTarget.isNode || currentPieceIndex < 0 || currentPieceIndex >= currentTarget.pieceHealthList.Count)
		{
			return;
		}
		int num = currentTarget.pieceHealthList[currentPieceIndex];
		if (num != lastKnownHealth)
		{
			lastKnownHealth = num;
			if (healthbar != null)
			{
				healthbar.SetCurrentHealth(num);
			}
		}
	}

	public void SetTarget(T_Item item, int pieceIndex)
	{
		if (item == null)
		{
			Hide();
			return;
		}
		if (!item.isNode)
		{
			Hide();
			return;
		}
		currentTarget = item;
		currentPieceIndex = pieceIndex;
		if (nameText != null && item.so != null)
		{
			string translation = LocalizationManager.GetTranslation(item.so.Name);
			nameText.text = (string.IsNullOrEmpty(translation) ? item.so.Name : translation);
		}
		if (healthbar != null && item.so != null)
		{
			healthbar.SetMaxHealth(item.so.nodeHealth);
			if (pieceIndex >= 0 && pieceIndex < item.pieceHealthList.Count)
			{
				lastKnownHealth = item.pieceHealthList[pieceIndex];
				healthbar.SetCurrentHealth(lastKnownHealth);
			}
			else
			{
				lastKnownHealth = item.so.nodeHealth;
				healthbar.SetCurrentHealth(lastKnownHealth);
			}
		}
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 1f;
		}
	}

	public void UpdateHealth(int health)
	{
		lastKnownHealth = health;
		if (healthbar != null)
		{
			healthbar.SetCurrentHealth(health);
		}
	}

	public void UpdatePieceIndex(int newPieceIndex)
	{
		if (!(currentTarget == null) && currentTarget.isNode)
		{
			currentPieceIndex = newPieceIndex;
			if (healthbar != null && currentTarget.so != null)
			{
				healthbar.SetMaxHealth(currentTarget.so.nodeHealth);
			}
			if (healthbar != null && newPieceIndex >= 0 && newPieceIndex < currentTarget.pieceHealthList.Count)
			{
				lastKnownHealth = currentTarget.pieceHealthList[newPieceIndex];
				healthbar.SetCurrentHealth(lastKnownHealth);
			}
		}
	}

	public void Hide()
	{
		currentTarget = null;
		currentPieceIndex = -1;
		lastKnownHealth = -1;
		if (canvasGroup != null)
		{
			canvasGroup.alpha = 0f;
		}
	}

	public T_Item GetCurrentTarget()
	{
		return currentTarget;
	}

	public int GetCurrentPieceIndex()
	{
		return currentPieceIndex;
	}

	public bool IsVisible()
	{
		if (canvasGroup != null)
		{
			return canvasGroup.alpha > 0f;
		}
		return false;
	}
}
