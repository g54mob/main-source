using System.Collections;
using System.IO;
using System.Xml.Linq;
using Assets.Scripts.Craft.Parts;
using Jundroo.Common.Utils;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class BlueprintScript : MonoBehaviour
	{
		private float _aspect;

		private Quaternion _baseRotation;

		private RawImage _image;

		private string _imagePath;

		private PartScript _mainCockpit;

		private IBlueprintsPanel _parent;

		private Vector2 _size;

		private RectTransform _transform;

		public bool Flipped { get; set; }

		public bool IsAligned { get; private set; }

		public bool IsShown => _image.enabled;

		public string Name { get; private set; }

		public Vector2 Offset { get; set; }

		public bool OverrideDisable { get; set; }

		public float Rotation { get; set; }

		public Vector2 Size
		{
			get
			{
				if (_transform != null)
				{
					_size = _transform.sizeDelta;
				}
				return _size;
			}
			set
			{
				_size = value;
				_aspect = value.y / value.x;
				if (_transform != null)
				{
					_transform.sizeDelta = value;
				}
			}
		}

		public XElement CreateXml()
		{
			return new XElement("Blueprint", new XAttribute("name", Name), new XAttribute("path", _imagePath), new XAttribute("baseRotation", _baseRotation.eulerAngles.ToXAttributeValue()), new XAttribute("rotation", Rotation), new XAttribute("size", Size.ToXAttributeValue()), new XAttribute("offset", Offset.ToXAttributeValue()), new XAttribute("flipped", Flipped));
		}

		public void Move(Vector2 amount)
		{
			Offset += amount;
		}

		public void SetHeight(float height)
		{
			_transform.sizeDelta = new Vector2(height / _aspect, height);
		}

		public void Setup(string name, string texturePath, Quaternion rotation, IBlueprintsPanel parent, bool copyTexture = false)
		{
			base.enabled = false;
			_image.enabled = false;
			_baseRotation = rotation;
			_parent = parent;
			_imagePath = texturePath;
			Name = name;
			base.transform.SetParent(GameObject.Find("BlueprintsCanvas").transform, worldPositionStays: false);
			base.transform.rotation = rotation;
			string pathForDocument = Game.Instance.GetPathForDocument("Blueprints");
			if (!Directory.Exists(pathForDocument))
			{
				Directory.CreateDirectory(pathForDocument);
			}
			string text = Path.Combine(pathForDocument, Name + ".png");
			if (text != texturePath)
			{
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				if (copyTexture)
				{
					File.Copy(texturePath, text);
				}
				else
				{
					File.Move(texturePath, text);
				}
				_imagePath = text;
			}
			StartCoroutine(Load(_imagePath));
		}

		public bool Setup(XElement xml, IBlueprintsPanel parent)
		{
			_parent = parent;
			base.enabled = false;
			_image.enabled = false;
			base.transform.SetParent(GameObject.Find("BlueprintsCanvas").transform, worldPositionStays: false);
			Name = xml.GetStringAttribute("name");
			if (Name == null)
			{
				return false;
			}
			_baseRotation = Quaternion.Euler(xml.GetVector3Attribute("baseRotation", Vector3.zero));
			Rotation = xml.GetFloatAttribute("rotation");
			base.transform.rotation = _baseRotation;
			Offset = xml.GetVector2Attribute("offset", Vector2.zero);
			Size = xml.GetVector2Attribute("size", Vector2.zero);
			Flipped = xml.GetBoolAttribute("flipped");
			_imagePath = xml.GetStringAttribute("path");
			if (_imagePath == null)
			{
				return false;
			}
			StartCoroutine(Load(_imagePath, setScale: false));
			return true;
		}

		public void SetWidth(float width)
		{
			_transform.sizeDelta = new Vector2(width, width * _aspect);
		}

		protected virtual void Awake()
		{
			_transform = base.gameObject.AddComponent<RectTransform>();
			base.gameObject.AddComponent<CanvasRenderer>();
			_image = base.gameObject.AddComponent<RawImage>();
		}

		protected virtual void Update()
		{
			PartScript mainCockpit = Designer.Instance.Aircraft.MainCockpit;
			if (mainCockpit != _mainCockpit)
			{
				if (_mainCockpit != null)
				{
					Vector3 vector = _mainCockpit.transform.position - mainCockpit.transform.position;
					Move(Quaternion.Inverse(_baseRotation) * vector);
				}
				_mainCockpit = mainCockpit;
			}
			IsAligned = Camera.main.orthographic && Utilities.CompareVector3s(Camera.main.transform.forward, base.transform.forward, 0.0001f);
			_image.enabled = IsAligned && !OverrideDisable;
			Rotation %= 360f;
			if (_image.enabled)
			{
				Vector3 position = Designer.Instance.DesignerScript.Aircraft.MainCockpit.transform.position;
				position = Quaternion.Inverse(_baseRotation) * position;
				position.z = 0f;
				position = _baseRotation * position;
				Vector3 position2 = Camera.main.transform.position + Camera.main.transform.forward * (Camera.main.farClipPlane - 1f);
				_transform.SetPositionAndRotation(Vector3.zero, _baseRotation);
				float z = _transform.InverseTransformPoint(position2).z;
				_transform.position = position + _transform.rotation * Offset + _transform.forward * z;
				_transform.Rotate(Vector3.forward, 0f - Rotation, Space.Self);
				_transform.localScale = new Vector3(Flipped ? (-1f) : 1f, 1f, 1f);
			}
		}

		private IEnumerator Load(string texPath, bool setScale = true)
		{
			UnityWebRequest www = UnityWebRequestTexture.GetTexture("file://" + texPath);
			yield return www.SendWebRequest();
			if (www.result != UnityWebRequest.Result.Success)
			{
				Debug.LogError("WWW error: " + www.error);
				Object.Destroy(base.gameObject);
				yield break;
			}
			Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
			_image.texture = texture;
			if (setScale)
			{
				_aspect = (float)texture.height / (float)texture.width;
				SetWidth(15f);
			}
			else
			{
				_aspect = _transform.sizeDelta.y / _transform.sizeDelta.x;
			}
			base.enabled = true;
			_image.enabled = true;
		}
	}
}
