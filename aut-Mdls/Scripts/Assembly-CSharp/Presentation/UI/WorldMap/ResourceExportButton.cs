using Data.ResourceTypes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI.WorldMap
{
	public class ResourceExportButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		private Image _icon;

		private ExportButtons _exportButtons;

		public bool IsExporting;

		private ResourceType _resourceType;

		private bool _isUnlocked;

		public ResourceType ResourceType => _resourceType;

		public void Export()
		{
			if (_isUnlocked)
			{
				_exportButtons.Export(this);
			}
		}

		public void Initialize(ExportButtons parent, ResourceType type, bool isUnlocked)
		{
			_exportButtons = parent;
			_resourceType = type;
			_icon.sprite = type.Icon;
			_isUnlocked = isUnlocked;
			if (!_isUnlocked)
			{
				_icon.color = Color.gray;
			}
		}

		public void ResetButton()
		{
			IsExporting = false;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_exportButtons.StopAnimationLine(this);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_exportButtons.AnimateLine(this);
		}
	}
}
