using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrintOverlay : MonoBehaviour
{
	private Renderer _renderer;

	private Material _instancedMat;

	private TMP_Text _text;

	private Image _image;

	private RectTransform _rectTransform;

	public float speed;

	public Ease ease;

	public float beamSpeed;

	public Ease beamEase;

	private Transform _trackThis;

	private Camera _mainCam;

	private Canvas _canvas;

	private PrintController _printControllerReference;

	private bool _isRevealed;

	private bool _facingPlayer;

	private void Awake()
	{
	}

	public void LateUpdate()
	{
	}

	public void Setup(Transform trackThis, PrintController caller)
	{
	}

	private bool IsFacingPlayer()
	{
		return false;
	}

	public void RevealLetter()
	{
	}

	public void ResetLetter()
	{
	}

	private void OnEnable()
	{
	}
}
