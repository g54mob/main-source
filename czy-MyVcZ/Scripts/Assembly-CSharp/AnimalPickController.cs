using System;
using UnityEngine;

public class AnimalPickController : MonoSingleton<AnimalPickController>
{
	private AnimalPos _pickedAnimalPos;

	private int _bgLayerMask;

	private Vector3 _pickedStartWorldPos;

	private int _justPickedFrame = -1;

	public event Action OnPickStartAnimalSpawnPos;

	public event Action OnPickEndAnimalSpawnPos;

	private void Update()
	{
		if (_pickedAnimalPos == null)
		{
			return;
		}
		Vector3 mousePosition = Input.mousePosition;
		if (mousePosition.x >= 0f && mousePosition.x <= (float)Screen.width && mousePosition.y >= 0f && mousePosition.y <= (float)Screen.height)
		{
			Vector3 position = Camera.main.ScreenToWorldPoint(mousePosition);
			position.z = 0f;
			_pickedAnimalPos.transform.position = position;
			if (Input.GetMouseButtonDown(0) && Time.frameCount != _justPickedFrame)
			{
				TryDropAtCursor();
			}
		}
		else
		{
			ReturnToStartAndDrop();
		}
	}

	public void Init()
	{
		_bgLayerMask = LayerMask.GetMask("BGCollider");
	}

	public void OnPickAnimalSpawnPos(AnimalPos animalPos)
	{
		if (!(_pickedAnimalPos != null) && animalPos.IsPickable())
		{
			_pickedAnimalPos = animalPos;
			_pickedStartWorldPos = animalPos.transform.position;
			_pickedAnimalPos.SetPickState();
			_justPickedFrame = Time.frameCount;
			MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Up);
			this.OnPickStartAnimalSpawnPos?.Invoke();
			Debug.Log("OnPickAnimalSpawnPos: " + animalPos.name);
		}
	}

	private void TryDropAtCursor()
	{
		bool num = IsMouseOverBGCollider();
		bool flag = IsMouseOverUpperGround();
		if (!num)
		{
			if (flag)
			{
				_pickedAnimalPos.SetPlaceUpperGround();
			}
			else
			{
				_pickedAnimalPos.SetPlaceLowerGround();
			}
			DropCurrent();
		}
		else
		{
			MonoSingleton<ToastManager>.Instance.ShowToast(LocaleHelper.Get("TOAST_NOTPLACE"));
		}
	}

	private bool IsMouseOverBGCollider()
	{
		RaycastHit2D[] rayIntersectionAll = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition), float.PositiveInfinity);
		bool flag = false;
		bool result = false;
		RaycastHit2D[] array = rayIntersectionAll;
		for (int i = 0; i < array.Length; i++)
		{
			RaycastHit2D raycastHit2D = array[i];
			if (!(raycastHit2D.collider == null))
			{
				int layer = raycastHit2D.collider.gameObject.layer;
				if (layer == LayerMask.NameToLayer("UpperGround"))
				{
					flag = true;
				}
				if (layer == LayerMask.NameToLayer("BGCollider"))
				{
					result = true;
				}
			}
		}
		if (flag)
		{
			return false;
		}
		return result;
	}

	private bool IsMouseOverUpperGround()
	{
		RaycastHit2D[] rayIntersectionAll = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition), float.PositiveInfinity);
		for (int i = 0; i < rayIntersectionAll.Length; i++)
		{
			RaycastHit2D raycastHit2D = rayIntersectionAll[i];
			if (!(raycastHit2D.collider == null) && raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer("UpperGround"))
			{
				return true;
			}
		}
		return false;
	}

	private void ReturnToStartAndDrop()
	{
		if (!(_pickedAnimalPos == null))
		{
			_pickedAnimalPos.transform.position = _pickedStartWorldPos;
			DropCurrent();
		}
	}

	private void DropCurrent()
	{
		if (!(_pickedAnimalPos == null))
		{
			_pickedAnimalPos.SetUnpickState();
			_pickedAnimalPos = null;
			MonoSingleton<SoundManager>.Instance.PlaySFX(SFXType.SFX_BTNCommon_Down);
			this.OnPickEndAnimalSpawnPos?.Invoke();
			MonoSingleton<GameManager>.Instance.SaveGame();
		}
	}
}
