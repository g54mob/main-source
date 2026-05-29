using CTS.Core;
using UnityEngine;

public class BuildableCursor : MonoBehaviour
{
	private static readonly int SHCursorColor = Shader.PropertyToID("_Color");

	[SerializeField]
	private Material _buildableCursorMaterial;

	[SerializeField]
	private Transform _meshContainer;

	[SerializeField]
	private Light _cursorLight;

	[SerializeField]
	[ColorUsage(true, true)]
	private Color _cursorInvalidColor = new Color(1f, 0f, 0f, 0.5f);

	[SerializeField]
	private Color _cursorInvalidLightColor = new Color(1f, 0f, 0f, 0.5f);

	[SerializeField]
	[ColorUsage(true, true)]
	private Color _cursorValidColor = new Color(0f, 1f, 0f, 0.5f);

	[SerializeField]
	private Color _cursorValidLightColor = new Color(0f, 1f, 0f, 0.5f);

	[SerializeField]
	private Texture _doorCookie;

	[SerializeField]
	private Texture _windowCookie;

	private GameObject _currentRemoverVisual;

	public void SetActive(bool active)
	{
		base.gameObject.SetActive(active);
	}

	public void SetApparence(BuildableElement element)
	{
		if (element == null)
		{
			_currentRemoverVisual = null;
			return;
		}
		GameObject getCurrentActiveVisual = element.GetCurrentActiveVisual;
		if (getCurrentActiveVisual == null)
		{
			_currentRemoverVisual = null;
		}
		else if (!(_currentRemoverVisual == getCurrentActiveVisual))
		{
			for (int i = 0; i < _meshContainer.childCount; i++)
			{
				Object.Destroy(_meshContainer.GetChild(i).gameObject);
			}
			Renderer[] componentsInChildren = getCurrentActiveVisual.GetComponentsInChildren<Renderer>();
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				GameObject obj = new GameObject();
				obj.transform.SetParent(_meshContainer);
				obj.transform.localPosition = componentsInChildren[j].transform.localPosition;
				obj.transform.localScale = componentsInChildren[j].transform.localScale;
				obj.transform.localRotation = Quaternion.identity;
				obj.AddComponent<MeshRenderer>().sharedMaterial = _buildableCursorMaterial;
				obj.AddComponent<MeshFilter>().mesh = componentsInChildren[j].GetComponent<MeshFilter>().sharedMesh;
			}
		}
	}

	private void Awake()
	{
		_buildableCursorMaterial = new Material(_buildableCursorMaterial);
	}

	public void SetValidColor(bool validColor)
	{
		_buildableCursorMaterial.SetColor(SHCursorColor, validColor ? _cursorValidColor : _cursorInvalidColor);
		_cursorLight.color = (validColor ? _cursorValidLightColor : _cursorInvalidLightColor);
	}

	public void SetApparenceFromSO(BuildableElementSO elementSO, bool isExteriorDoor = false)
	{
		for (int i = 0; i < _meshContainer.childCount; i++)
		{
			Object.Destroy(_meshContainer.GetChild(i).gameObject);
		}
		if (elementSO == null || elementSO.BuildableType == BuildableElementSO.EBuildableType.Room)
		{
			_cursorLight.enabled = false;
			return;
		}
		Renderer[] array = ((!isExteriorDoor || !(elementSO.Prefab is BuildableDoor buildableDoor)) ? elementSO.Prefab.CursorRenderers : buildableDoor.ExteriorCursorRenderers);
		_cursorLight.enabled = true;
		Light cursorLight = _cursorLight;
		Texture cookie = ((MonoSingleton<BuildablePlacementSystem>.Instance.CurrentSelectedBuildable.BuildableType != BuildableElementSO.EBuildableType.Window) ? _doorCookie : _windowCookie);
		cursorLight.cookie = cookie;
		for (int j = 0; j < array.Length; j++)
		{
			GameObject obj = new GameObject();
			obj.transform.SetParent(_meshContainer);
			obj.transform.localPosition = array[j].transform.localPosition;
			obj.transform.localScale = array[j].transform.localScale;
			obj.transform.localRotation = Quaternion.identity;
			obj.AddComponent<MeshRenderer>().sharedMaterial = _buildableCursorMaterial;
			obj.AddComponent<MeshFilter>().mesh = array[j].GetComponent<MeshFilter>().sharedMesh;
		}
	}
}
