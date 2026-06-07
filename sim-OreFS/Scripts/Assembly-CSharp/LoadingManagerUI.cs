using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LoadingManagerUI : MonoBehaviour
{
	[Header("UI References")]
	[SerializeField]
	private TextMeshProUGUI reasonText;

	[Header("Settings")]
	[SerializeField]
	private float hideDelay = 1.5f;

	[Header("Events")]
	public UnityEvent<LoadingType> OnLoadingStarted;

	public UnityEvent<LoadingType> OnLoadingFinished;

	public UnityEvent<string> OnReasonTextChanged;

	[Header("State (Debug)")]
	[SerializeField]
	private bool isLoading;

	[SerializeField]
	private LoadingType displayedLoadingType;

	private HashSet<LoadingType> activeLoadings = new HashSet<LoadingType>();

	private Coroutine hideCoroutine;

	public static LoadingManagerUI Instance { get; private set; }

	public bool IsLoading => activeLoadings.Count > 0;

	public LoadingType CurrentLoadingType => displayedLoadingType;

	public int ActiveLoadingCount => activeLoadings.Count;

	public bool IsLoadingActive(LoadingType type)
	{
		return activeLoadings.Contains(type);
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Debug.Log("[LoadingManagerUI] Zaten bir instance var, yeni olan siliniyor.");
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
			Debug.Log("[LoadingManagerUI] Instance oluşturuldu ve DontDestroyOnLoad uygulandı.");
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void ShowLoading(LoadingType loadingType, string reason = null)
	{
		CancelHideCoroutine();
		bool num = activeLoadings.Count == 0;
		activeLoadings.Add(loadingType);
		displayedLoadingType = loadingType;
		isLoading = true;
		UpdateReasonText(GetLocalizedReason(loadingType));
		Debug.Log(string.Format("[LoadingManagerUI] Show: {0} | Aktif: [{1}] | Toplam: {2}", loadingType, string.Join(", ", activeLoadings), activeLoadings.Count));
		if (num)
		{
			OnLoadingStarted?.Invoke(loadingType);
		}
	}

	private string GetLocalizedReason(LoadingType loadingType)
	{
		return loadingType switch
		{
			LoadingType.Scene => LocalizationManager.GetTranslation("Loading_Scene"), 
			LoadingType.Menu => LocalizationManager.GetTranslation("Loading_Menu"), 
			LoadingType.Property => LocalizationManager.GetTranslation("Loading_Property"), 
			LoadingType.Ore => LocalizationManager.GetTranslation("Loading_Ore"), 
			LoadingType.Digger => LocalizationManager.GetTranslation("Loading_Digger"), 
			LoadingType.PlayerJoining => LocalizationManager.GetTranslation("Loading_PlayerJoining"), 
			LoadingType.JoiningRoom => LocalizationManager.GetTranslation("Loading_JoiningRoom"), 
			LoadingType.CreatingRoom => LocalizationManager.GetTranslation("Loading_CreatingRoom"), 
			_ => LocalizationManager.GetTranslation("Loading_Scene"), 
		};
	}

	public void HideLoading(LoadingType loadingType)
	{
		if (!activeLoadings.Contains(loadingType))
		{
			Debug.Log($"[LoadingManagerUI] HideLoading({loadingType}) atlandı - zaten aktif değil.");
			return;
		}
		activeLoadings.Remove(loadingType);
		Debug.Log(string.Format("[LoadingManagerUI] Hide: {0} | Kalan: [{1}] | Toplam: {2}", loadingType, string.Join(", ", activeLoadings), activeLoadings.Count));
		if (activeLoadings.Count == 0)
		{
			if (hideCoroutine == null)
			{
				hideCoroutine = StartCoroutine(HideLoadingCoroutine(loadingType));
			}
		}
		else if (loadingType == displayedLoadingType)
		{
			UpdateDisplayedType();
		}
	}

	public void HideLoadingImmediate(LoadingType loadingType)
	{
		CancelHideCoroutine();
		if (activeLoadings.Contains(loadingType))
		{
			activeLoadings.Remove(loadingType);
			Debug.Log(string.Format("[LoadingManagerUI] HideImmediate: {0} | Kalan: [{1}] | Toplam: {2}", loadingType, string.Join(", ", activeLoadings), activeLoadings.Count));
			if (activeLoadings.Count == 0)
			{
				ExecuteHide(loadingType);
			}
			else if (loadingType == displayedLoadingType)
			{
				UpdateDisplayedType();
			}
		}
	}

	public void HideAllLoadings()
	{
		if (activeLoadings.Count == 0 && !isLoading)
		{
			return;
		}
		if (SaveLoadGameManager.IsLoadPendingOrInProgress)
		{
			Debug.Log("[LoadingManagerUI] HideAllLoadings atlandı - load pending/in progress.");
			return;
		}
		LoadingType finishedType = displayedLoadingType;
		activeLoadings.Clear();
		Debug.Log("[LoadingManagerUI] HideAll: Tüm loading'ler temizlendi.");
		if (hideCoroutine == null)
		{
			hideCoroutine = StartCoroutine(HideLoadingCoroutine(finishedType));
		}
	}

	public void HideAllLoadingsImmediate()
	{
		CancelHideCoroutine();
		if (activeLoadings.Count != 0 || isLoading)
		{
			LoadingType finishedType = displayedLoadingType;
			activeLoadings.Clear();
			Debug.Log("[LoadingManagerUI] HideAllImmediate: Tüm loading'ler temizlendi.");
			ExecuteHide(finishedType);
		}
	}

	private void UpdateDisplayedType()
	{
		using HashSet<LoadingType>.Enumerator enumerator = activeLoadings.GetEnumerator();
		if (enumerator.MoveNext())
		{
			UpdateReasonText(GetLocalizedReason(displayedLoadingType = enumerator.Current));
		}
	}

	private IEnumerator HideLoadingCoroutine(LoadingType finishedType)
	{
		yield return new WaitForSeconds(hideDelay);
		if (activeLoadings.Count > 0)
		{
			hideCoroutine = null;
			UpdateDisplayedType();
		}
		else
		{
			ExecuteHide(finishedType);
			hideCoroutine = null;
		}
	}

	private void ExecuteHide(LoadingType finishedType)
	{
		if (!isLoading)
		{
			return;
		}
		if (SaveLoadGameManager.IsLoadPendingOrInProgress)
		{
			Debug.Log($"[LoadingManagerUI] ExecuteHide({finishedType}) engellendi - load pending/in progress.");
			return;
		}
		Debug.Log($"[LoadingManagerUI] ExecuteHide çağrıldı! FinishedType: {finishedType}, Pending: {SaveLoadGameManager.HasPendingOperations}, Stack:\n{StackTraceUtility.ExtractStackTrace()}");
		isLoading = false;
		displayedLoadingType = LoadingType.Scene;
		SaveLoadGameManager.ReleaseAllKinematics();
		if (NewNetworkManager.Instance != null && NewNetworkManager.Instance.GetCurrentPlayerCount() == 1)
		{
			NewNetworkManager.Instance.SetJoinEnabled(enabled: true);
			SaveLoadGameManager.isLoadMode = false;
		}
		OnLoadingFinished?.Invoke(finishedType);
	}

	private void CancelHideCoroutine()
	{
		if (hideCoroutine != null)
		{
			StopCoroutine(hideCoroutine);
			hideCoroutine = null;
		}
	}

	public void UpdateReasonText(string reason)
	{
		if (reasonText != null)
		{
			reasonText.text = reason;
		}
		OnReasonTextChanged?.Invoke(reason);
	}

	public static void Show(LoadingType loadingType, string reason = "")
	{
		if (Instance != null)
		{
			Instance.ShowLoading(loadingType, reason);
		}
		else
		{
			Debug.LogWarning("[LoadingManagerUI] Instance bulunamadı!");
		}
	}

	public static void Hide(LoadingType loadingType)
	{
		if (Instance != null)
		{
			Instance.HideLoading(loadingType);
		}
		else
		{
			Debug.LogWarning("[LoadingManagerUI] Instance bulunamadı!");
		}
	}

	public static void HideImmediate(LoadingType loadingType)
	{
		if (Instance != null)
		{
			Instance.HideLoadingImmediate(loadingType);
		}
		else
		{
			Debug.LogWarning("[LoadingManagerUI] Instance bulunamadı!");
		}
	}

	public static void HideAll()
	{
		if (Instance != null)
		{
			Instance.HideAllLoadings();
		}
		else
		{
			Debug.LogWarning("[LoadingManagerUI] Instance bulunamadı!");
		}
	}

	public static void HideAllImmediate()
	{
		if (Instance != null)
		{
			Instance.HideAllLoadingsImmediate();
		}
		else
		{
			Debug.LogWarning("[LoadingManagerUI] Instance bulunamadı!");
		}
	}

	public static void UpdateReason(string reason)
	{
		if (Instance != null)
		{
			Instance.UpdateReasonText(reason);
		}
		else
		{
			Debug.LogWarning("[LoadingManagerUI] Instance bulunamadı!");
		}
	}
}
