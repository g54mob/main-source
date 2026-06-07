using System.Collections;
using UnityEngine;

public class DetectorFeedback : MonoBehaviour
{
	[Header("References")]
	[SerializeField]
	private DetectorScanner scanner;

	[Header("Visual Settings")]
	[Tooltip("Yoğunluk gösterge LED'i (MeshRenderer veya SpriteRenderer)")]
	[SerializeField]
	private Renderer ledRenderer;

	[SerializeField]
	private string emissionColorProperty = "_EmissionColor";

	[Tooltip("Düşük yoğunlukta LED rengi")]
	[SerializeField]
	private Color lowIntensityColor = Color.green;

	[Tooltip("Yüksek yoğunlukta LED rengi")]
	[SerializeField]
	private Color highIntensityColor = Color.red;

	[SerializeField]
	private float emissionIntensity = 2f;

	[Header("Audio Settings")]
	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip beepClip;

	[SerializeField]
	[Range(0f, 1f)]
	private float beepVolume = 0.5f;

	[Tooltip("En uzak mesafede bip aralığı")]
	[SerializeField]
	private float maxBeepInterval = 1.5f;

	[Tooltip("En yakın mesafede bip aralığı")]
	[SerializeField]
	private float minBeepInterval = 0.1f;

	[Header("Blink Object Settings")]
	[Tooltip("Bip sesinde kapanıp açılacak obje")]
	[SerializeField]
	private GameObject blinkObject;

	[Tooltip("Objenin kapalı kalma süresi")]
	[SerializeField]
	private float blinkDuration = 0.1f;

	[Header("State")]
	[SerializeField]
	private bool enableLED = true;

	[SerializeField]
	private bool enableAudio = true;

	private MaterialPropertyBlock propertyBlock;

	private float _nextBeepTime;

	private float _currentBeepInterval = 1.5f;

	private Coroutine _blinkCoroutine;

	private void Start()
	{
		if (scanner == null)
		{
			scanner = GetComponent<DetectorScanner>();
		}
		if (scanner == null)
		{
			scanner = GetComponentInParent<DetectorScanner>();
		}
		propertyBlock = new MaterialPropertyBlock();
	}

	private void Update()
	{
		if (!(scanner == null))
		{
			float currentIntensity = scanner.GetCurrentIntensity();
			if (enableLED && ledRenderer != null)
			{
				UpdateLED(currentIntensity);
			}
			if (enableAudio && audioSource != null && beepClip != null)
			{
				UpdateBeep(currentIntensity);
			}
		}
	}

	private void UpdateLED(float intensity)
	{
		if (!(ledRenderer == null))
		{
			Color value = Color.Lerp(lowIntensityColor, highIntensityColor, intensity) * emissionIntensity;
			ledRenderer.GetPropertyBlock(propertyBlock);
			propertyBlock.SetColor(emissionColorProperty, value);
			ledRenderer.SetPropertyBlock(propertyBlock);
		}
	}

	private void UpdateBeep(float intensity)
	{
		if (intensity <= 0f)
		{
			return;
		}
		float num = Mathf.Lerp(maxBeepInterval, minBeepInterval, intensity);
		if (num < _currentBeepInterval)
		{
			float num2 = Time.time + num;
			if (num2 < _nextBeepTime)
			{
				_nextBeepTime = num2;
			}
		}
		_currentBeepInterval = num;
		if (Time.time >= _nextBeepTime)
		{
			audioSource.PlayOneShot(beepClip, beepVolume);
			_nextBeepTime = Time.time + _currentBeepInterval;
			if (blinkObject != null)
			{
				TriggerBlink();
			}
		}
	}

	private void TriggerBlink()
	{
		if (_blinkCoroutine != null)
		{
			StopCoroutine(_blinkCoroutine);
		}
		_blinkCoroutine = StartCoroutine(BlinkCoroutine());
	}

	private IEnumerator BlinkCoroutine()
	{
		blinkObject.SetActive(value: false);
		yield return new WaitForSeconds(blinkDuration);
		blinkObject.SetActive(value: true);
		_blinkCoroutine = null;
	}

	public void SetLEDEnabled(bool enabled)
	{
		enableLED = enabled;
	}

	public void SetAudioEnabled(bool enabled)
	{
		enableAudio = enabled;
	}
}
