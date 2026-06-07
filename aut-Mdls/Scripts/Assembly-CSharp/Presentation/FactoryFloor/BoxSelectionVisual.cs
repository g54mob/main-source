using System.Collections.Generic;
using Events;
using Events.FactoryFloor;
using Events.Generic;
using Presentation.Locators;
using Shapes;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class BoxSelectionVisual : MonoBehaviour
	{
		private static readonly int Color1 = Shader.PropertyToID("_Color");

		[SerializeField]
		private MeshRenderer _quad;

		[SerializeField]
		private MeshRenderer _selectionBoxWalls;

		[SerializeField]
		private List<Polyline> _polyLines;

		[SerializeField]
		private float _selectionMaxHeight = 3f;

		[SerializeField]
		private BoxEvent _updateBoxSize;

		[SerializeField]
		private ColorEvent _updateSelectionBoxColor;

		[SerializeField]
		private BaseEvent _disableBox;

		[SerializeField]
		private GridLocator _gridLocator;

		private MaterialPropertyBlock _propertyBlock;

		private Color _currentColor;

		private void Start()
		{
			_updateBoxSize.Register(UpdateBoxSize);
			_disableBox.Register(DisableBox);
			_updateSelectionBoxColor.Register(UpdateBoxColor);
			DisableBox();
			_propertyBlock = new MaterialPropertyBlock();
		}

		private void EnableBox()
		{
			_quad.gameObject.SetActive(value: true);
			_selectionBoxWalls.gameObject.SetActive(value: true);
			foreach (Polyline polyLine in _polyLines)
			{
				polyLine.gameObject.SetActive(value: true);
			}
		}

		private void DisableBox()
		{
			_quad.gameObject.SetActive(value: false);
			_selectionBoxWalls.gameObject.SetActive(value: false);
			foreach (Polyline polyLine in _polyLines)
			{
				polyLine.gameObject.SetActive(value: false);
			}
		}

		private void OnDestroy()
		{
			_disableBox.UnRegister(DisableBox);
			_updateBoxSize.UnRegister(UpdateBoxSize);
			_updateSelectionBoxColor.UnRegister(UpdateBoxColor);
		}

		private void UpdateBoxColor(Color color)
		{
			if (color == _currentColor)
			{
				return;
			}
			_currentColor = color;
			_propertyBlock.SetColor(Color1, color);
			_quad.SetPropertyBlock(_propertyBlock);
			_selectionBoxWalls.SetPropertyBlock(_propertyBlock);
			foreach (Polyline polyLine in _polyLines)
			{
				polyLine.Color = Color.white;
			}
		}

		private void UpdateBoxSize(BoxSize obj)
		{
			EnableBox();
			Vector2 size = GetSize(obj);
			Vector3 center = GetCenter(obj);
			center.y = 0f;
			base.transform.position = center;
			_quad.transform.localScale = new Vector3(size.x, size.y, 1f);
			_selectionBoxWalls.transform.localScale = new Vector3(size.x, _selectionMaxHeight, size.y);
			float y = Mathf.Min(size.x, size.y, _selectionMaxHeight);
			foreach (Polyline polyLine in _polyLines)
			{
				polyLine.transform.localScale = new Vector3(size.x, y, size.y);
			}
		}

		private Vector3 GetCenter(BoxSize boxSize)
		{
			Vector3 worldPosition = _gridLocator.GetWorldPosition(boxSize.StartPosition);
			Vector3 worldPosition2 = _gridLocator.GetWorldPosition(boxSize.EndPosition);
			Vector3 result = (worldPosition + worldPosition2) / 2f;
			result.y = 0f;
			return result;
		}

		private Vector2 GetSize(BoxSize boxSize)
		{
			int num = Mathf.Abs(boxSize.EndPosition.x - boxSize.StartPosition.x) + 1;
			int num2 = Mathf.Abs(boxSize.EndPosition.z - boxSize.StartPosition.z) + 1;
			return new Vector2(num, num2);
		}
	}
}
