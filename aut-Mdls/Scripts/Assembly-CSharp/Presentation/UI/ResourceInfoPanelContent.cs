using Data.FactoryFloor.Resources;
using Data.Shapes;
using Data.Variables.Resources;
using Events.UI;
using NaughtyAttributes;
using UnityEngine;

namespace Presentation.UI
{
	public class ResourceInfoPanelContent : InfoPanelContent
	{
		[SerializeField]
		private NonShapeResourceDataSO _resourceDataSo;

		[SerializeField]
		private ShapeData _shapeData;

		[SerializeField]
		private bool _hideOrigin;

		[SerializeField]
		private bool _showAmountInfo;

		[SerializeField]
		[ShowIf("_showAmountInfo")]
		private ResourceAmountInfo _resourceAmountInfo;

		private bool _isResource;

		private bool _isShape;

		public void ClearContent()
		{
			_resourceDataSo = null;
			_shapeData = null;
			_isResource = false;
			_isShape = false;
		}

		public void UpdateContent(NonShapeResourceDataSO resourceDataSo)
		{
			_isResource = true;
			_isShape = false;
			_resourceDataSo = resourceDataSo;
		}

		public void UpdateContent(ShapeData shapeData)
		{
			_isResource = false;
			_isShape = true;
			_shapeData = shapeData;
		}

		public void UpdateAmountInfo(int amount, int totalAmount)
		{
			if (base.IsOpen)
			{
				_resourceAmountInfo.SetValue(amount, totalAmount);
			}
		}

		protected override InfoPanelDto GetInfoPanelDto()
		{
			ResourceInfoPanelDto result = null;
			if (_isResource)
			{
				result = new ResourceInfoPanelDto(_resourceDataSo, _hideOrigin, _resourceAmountInfo);
			}
			else if (_isShape)
			{
				result = new ResourceInfoPanelDto(_shapeData, _hideOrigin, _resourceAmountInfo);
			}
			return result;
		}
	}
}
