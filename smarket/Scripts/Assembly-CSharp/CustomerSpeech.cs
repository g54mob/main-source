using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

public class CustomerSpeech : MonoBehaviour
{
	[SerializeField]
	private TMP_Text m_SpeechText;

	[SerializeField]
	private LocalizeStringEvent m_LocalizeStringEvent;

	[SerializeField]
	private float m_OrthoCamSmoothness;

	private Transform m_player;

	public float SpeechTextFontSize => 0f;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLocalPlayerUpdated(PlayerInstance _instance)
	{
	}

	private void Update()
	{
	}

	public void Setup(string tableCollection, string key, params string[] args)
	{
	}
}
