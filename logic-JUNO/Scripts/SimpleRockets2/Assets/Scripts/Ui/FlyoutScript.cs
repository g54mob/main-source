using ModApi.Ui;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui
{
	public class FlyoutScript : MonoBehaviour, IFlyout
	{
		private bool _isHidden;

		private XmlElement _xmlElement;

		public bool IsHidden
		{
			get
			{
				return _isHidden;
			}
			set
			{
				if (_isHidden != value)
				{
					_isHidden = value;
					if (value)
					{
						_xmlElement.Hide();
					}
					else
					{
						_xmlElement.Show();
					}
				}
			}
		}

		public bool IsOpen { get; private set; }

		public string Title
		{
			get
			{
				return _xmlElement.GetElementByInternalId("flyout-title").GetAttribute("text");
			}
			set
			{
				_xmlElement.GetElementByInternalId("flyout-title").SetAndApplyAttribute("text", value);
			}
		}

		public RectTransform Transform => _xmlElement.GetComponent<RectTransform>();

		public float Width
		{
			get
			{
				return Transform.sizeDelta.x;
			}
			set
			{
				Vector2 sizeDelta = Transform.sizeDelta;
				Transform.sizeDelta = new Vector2(value, sizeDelta.y);
			}
		}

		public event FlyoutDelegate Closed;

		public event FlyoutDelegate Closing;

		public event FlyoutDelegate Opened;

		public event FlyoutDelegate Opening;

		public void AddClass(string className)
		{
			_xmlElement.AddClass(className);
		}

		public virtual void Close(bool immediate = false)
		{
			_isHidden = true;
			IsOpen = false;
			this.Closing?.Invoke(this);
			_xmlElement.SetActive(active: false);
			this.Closed?.Invoke(this);
		}

		public void Initialize(XmlElement xmlElement)
		{
			_xmlElement = xmlElement;
		}

		public virtual void Open(bool immediate = false)
		{
			_isHidden = false;
			IsOpen = true;
			this.Opening?.Invoke(this);
			_xmlElement.SetActive(active: true);
			this.Opened?.Invoke(this);
		}

		public void RemoveClass(string className)
		{
			_xmlElement.RemoveClass(className);
		}
	}
}
