using System.Collections;
using UnityEngine;

public class SettingsSlider : MonoBehaviour
{
	public float maxSlide = 0.4375f;

	public bool vertical;

	public SettingsMenu owner;

	public float val = 0.5f;

	public SpriteRenderer shadowHandle;

	public SpriteRenderer shadowBG;

	public bool NoAutoSet;

	private bool sfx;

	public float scrollSpeed => maxSlide * 2f / 50f;

	public void Awake()
	{
		if (vertical)
		{
			Transform obj = shadowBG.transform;
			Vector3 localPosition = (shadowHandle.transform.localPosition = new Vector3(-0.0625f, 0f));
			obj.localPosition = localPosition;
		}
		else
		{
			Transform obj2 = shadowBG.transform;
			Vector3 localPosition = (shadowHandle.transform.localPosition = new Vector3(0f, -0.0625f));
			obj2.localPosition = localPosition;
		}
	}

	public void Start()
	{
		if (!NoAutoSet)
		{
			base.transform.localPosition = Vector3.zero;
			val = 0.5f;
			Set();
		}
	}

	public void Preset(float v)
	{
		NoAutoSet = true;
		val = v;
		base.transform.localPosition = new Vector3(v * 2f * maxSlide - maxSlide, base.transform.localPosition.y);
		owner.ReadSliders(this);
	}

	public void Set()
	{
		float num = val;
		val = (base.transform.localPosition.x + maxSlide) / (2f * maxSlide);
		if (num < val)
		{
			Dungeon.Instance.animationManager.LerpRotate(base.gameObject, new Vector3(0f, 0f, (GetMousePos().y > base.transform.position.y) ? (-5) : 5), 3f, 0f, UI: true);
			Dungeon.Instance.animationManager.LerpRotate(base.gameObject, new Vector3(0f, 0f, 0f), 10f, 0f, UI: true);
			StartCoroutine(PlaySound());
		}
		else if (num > val)
		{
			Dungeon.Instance.animationManager.LerpRotate(base.gameObject, new Vector3(0f, 0f, (GetMousePos().y > base.transform.position.y) ? 5 : (-5)), 3f, 0f, UI: true);
			Dungeon.Instance.animationManager.LerpRotate(base.gameObject, new Vector3(0f, 0f, 0f), 10f, 0f, UI: true);
			StartCoroutine(PlaySound());
		}
		owner.ReadSliders(this);
	}

	private IEnumerator PlaySound()
	{
		if (!sfx)
		{
			sfx = true;
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.Slider);
			yield return Dungeon.WaitUI(3);
			sfx = false;
		}
	}

	public static Vector3 GetMousePos()
	{
		return Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(0f, 0f, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
	}

	private void OnMouseDrag()
	{
		if (vertical)
		{
			base.transform.position = new Vector3(0f, GetMousePos().y);
			base.transform.localPosition = new Vector3(Mathf.Clamp(base.transform.localPosition.x, 0f - maxSlide, maxSlide), 0f);
		}
		else
		{
			base.transform.position = new Vector3(GetMousePos().x, 0f);
			base.transform.localPosition = new Vector3(Mathf.Clamp(base.transform.localPosition.x, 0f - maxSlide, maxSlide), 0f);
		}
		Set();
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}

	public void PlaySFX()
	{
		StartCoroutine(PlaySound());
	}

	public void ScrollUp()
	{
		base.transform.localPosition = new Vector3(Mathf.Clamp(base.transform.localPosition.x + scrollSpeed, 0f - maxSlide, maxSlide), 0f);
		PlaySFX();
		Set();
	}

	public void ScrollDown()
	{
		base.transform.localPosition = new Vector3(Mathf.Clamp(base.transform.localPosition.x - scrollSpeed, 0f - maxSlide, maxSlide), 0f);
		PlaySFX();
		Set();
	}

	public void ResetSlider()
	{
		base.transform.localPosition = Vector3.zero;
		val = 0.5f;
		PlaySFX();
		Set();
	}

	private void OnMouseOver()
	{
		if (Input.mouseScrollDelta.y > 0f)
		{
			ScrollUp();
		}
		if (Input.mouseScrollDelta.y < 0f)
		{
			ScrollDown();
		}
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			ResetSlider();
		}
	}
}
