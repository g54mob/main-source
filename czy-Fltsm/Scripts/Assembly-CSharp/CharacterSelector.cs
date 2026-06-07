using System;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
	[SerializeField]
	private CrewExpertisePanel _expertisePanel;

	[SerializeField]
	private CharacterPreview[] _previews;

	[SerializeField]
	private float _previewOffset = 10f;

	[SerializeField]
	private Vector3 _previewCameraParentPosition = new Vector3(0f, -1000f, 0f);

	private Transform _cameraParent;

	public CharacterPreview[] AgentPreviews => _previews;

	public void Initialize()
	{
		if (GameManager.Settings.SessionSettings.StartingScenario.Inhabitants != _previews.Length)
		{
			throw new ArgumentException("Character selector preview count does not match the player community agent count.");
		}
		_cameraParent = new GameObject().transform;
		_cameraParent.name = "StartMessage Camera Parent";
		_cameraParent.position = _previewCameraParentPosition;
		for (int i = 0; i < _previews.Length; i++)
		{
			_previews[i].Initialize(_cameraParent, Vector3.right * (_previewOffset * (float)i));
		}
		if (_previews.Length != 0)
		{
			CharacterPreview leftNeighbor = null;
			CharacterPreview characterPreview = _previews[0];
			int num = _previews.Length - 1;
			for (int j = 0; j <= num; j++)
			{
				CharacterPreview characterPreview2 = ((j == num) ? null : _previews[j + 1]);
				characterPreview.InitializeHorizontalNavigation(leftNeighbor, characterPreview2);
				leftNeighbor = characterPreview;
				characterPreview = characterPreview2;
			}
		}
		if (_expertisePanel != null)
		{
			_expertisePanel.Initialize();
		}
	}

	private void OnEnable()
	{
		if ((bool)_cameraParent)
		{
			_cameraParent.gameObject.SetActive(value: true);
		}
	}

	private void OnDisable()
	{
		if ((bool)_cameraParent)
		{
			_cameraParent.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		if ((bool)_cameraParent)
		{
			UnityEngine.Object.Destroy(_cameraParent);
		}
	}
}
