using System.Linq;
using System.Xml.Linq;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;

namespace Jundroo.Juicy.Widgets
{
	public class FileWidget : Widget
	{
		private string _path;

		[SerializeField]
		private bool _pathChanged;

		public bool AutoRefresh { get; set; }

		public bool Inline
		{
			get
			{
				return false;
			}
			set
			{
				if (value)
				{
					Debug.LogError("Inline property cannot be enabled after a File Widget has been loaded.");
				}
			}
		}

		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value;
				_pathChanged = true;
			}
		}

		protected override AttributeSet AttributeSet => FileAttributes.Set;

		public override void Initialize(IWidgetContext context, XElement element)
		{
			base.Initialize(context, element);
		}

		public override void UpdateWidget(object dataModel)
		{
			base.UpdateWidget(dataModel);
			if (!_pathChanged)
			{
				return;
			}
			_pathChanged = false;
			foreach (Widget item in base.Widgets.ToList())
			{
				item.Destroy();
			}
			base.Context.LoadWidgetFromXml(Path, this);
		}
	}
}
