using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design;
using Assets.Scripts.Storage;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Scenes.PartIconStudio
{
	public class StudioScript : MonoBehaviour
	{
		public int StartIndex;

		private Camera _cam;

		private DesignerPart _currentPart;

		private List<DesignerPart> _designerParts = new List<DesignerPart>();

		private int _index;

		[SerializeField]
		private Light _light;

		[SerializeField]
		private PartStudioData _partStudioData;

		private bool _render;

		public AircraftScript Aircraft { get; set; }

		public string DocumentsPath => GameData.PersistentDataPath;

		public void LoadAircraft()
		{
			AircraftData aircraft = new AircraftData(new XElement(XDocument.Parse((Resources.Load("Data/PartIconStudioAircraft") as TextAsset).text).Element("Aircraft")), CraftLoadContext.Studio);
			PartData.PartCreationInfo partCreationInfo = new PartData.PartCreationInfo();
			partCreationInfo.CreateHingeJoints = false;
			partCreationInfo.IsRigidBodyKinematic = true;
			partCreationInfo.CreateRigidBody = false;
			partCreationInfo.EnableWingScript = false;
			Aircraft = AircraftData.GenerateGameObject(aircraft, partCreationInfo, 0).GetComponent<AircraftScript>();
			Aircraft.RebuildAircraftStructure();
		}

		public void LoadPart(DesignerPart designerPart)
		{
			if (_currentPart != null)
			{
				PartStudioData.PartIconData partIconData = _partStudioData.GetPart(_currentPart.Name);
				if (partIconData == null)
				{
					partIconData = new PartStudioData.PartIconData();
					partIconData.partId = _currentPart.Name;
					_partStudioData.parts.Add(partIconData);
				}
				partIconData.rotation = Aircraft.transform.localRotation;
				partIconData.scale = Aircraft.transform.localScale.x;
				partIconData.position = Aircraft.transform.localPosition;
			}
			_currentPart = null;
			foreach (PartData item in Aircraft.Aircraft.Assembly.Parts.ToList())
			{
				Aircraft.Aircraft.Assembly.RemovePart(item);
				item.PartScript.transform.parent = null;
				item.PartScript.gameObject.SetActive(value: false);
				Object.Destroy(item.PartScript.gameObject);
			}
			PartData.PartCreationInfo partCreationInfo = new PartData.PartCreationInfo();
			partCreationInfo.CreateHingeJoints = false;
			partCreationInfo.IsRigidBodyKinematic = true;
			partCreationInfo.CreateRigidBody = false;
			partCreationInfo.EnableWingScript = false;
			Assembly assembly = new Assembly(designerPart.AssemblyElement, 23, CraftLoadContext.Studio);
			assembly.CreateGameObjects(Aircraft, partCreationInfo, Aircraft.Children);
			Aircraft.Aircraft.Assembly.Absorb(assembly);
			AdaptiveBlockScript.UpdateAdaptiveBlockStates(Aircraft.Aircraft.Assembly.Parts);
			Camera component = base.transform.Find("CameraTarget/Camera").GetComponent<Camera>();
			component.transform.LookAt(Vector3.zero);
			float num = designerPart.StudioScale * 0.5f;
			foreach (PartData part2 in Aircraft.Aircraft.Assembly.Parts)
			{
				WingScript modifier = part2.PartScript.GetModifier<WingScript>();
				if (modifier != null)
				{
					Vector3 vector = modifier.transform.TransformPoint(modifier.Wing.TipPosition);
					vector *= 0.5f;
					part2.PartScript.transform.position = -vector * num;
					designerPart.StudioOffset = new Vector3(-0.01f, 0f, 0f);
				}
				Vector3 vector2 = component.transform.right * designerPart.StudioOffset.x + component.transform.up * designerPart.StudioOffset.y;
				part2.PartScript.transform.position += vector2;
				part2.PartScript.transform.localScale = new Vector3(num, num, num);
				part2.PartScript.transform.localRotation = Quaternion.Euler(designerPart.StudioRotation);
			}
			_currentPart = designerPart;
			PartStudioData.PartIconData part = _partStudioData.GetPart(designerPart.Name);
			if (part != null)
			{
				Aircraft.transform.localRotation = part.rotation;
				Aircraft.transform.localScale = part.scale * Vector3.one;
				Aircraft.transform.localPosition = part.position;
			}
		}

		protected virtual void LateUpdate()
		{
			if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
			{
				_render = true;
			}
			Vector3 vector = Vector3.zero;
			float num = 1f;
			if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad4))
			{
				vector = new Vector3(0.01f, 0f, 0f);
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad6))
			{
				vector = new Vector3(-0.01f, 0f, 0f);
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad8))
			{
				vector = new Vector3(0f, 0.01f, 0f);
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad2))
			{
				vector = new Vector3(0f, -0.01f, 0f);
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad7))
			{
				vector = new Vector3(0f, 0f, -0.01f);
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.Keypad1))
			{
				vector = new Vector3(0f, 0f, 0.01f);
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadPlus))
			{
				num *= 1.05f;
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				num *= 0.95f;
			}
			if (!Utilities.CompareVector3s(vector, Vector3.zero) || !Utilities.CompareFloats(num, 1f))
			{
				Aircraft.transform.localPosition += vector;
				Aircraft.transform.localScale *= num;
				_render = true;
			}
			if (_render)
			{
				_render = false;
				StartCoroutine(RenderPart());
			}
		}

		protected virtual void Start()
		{
			Debug.Log("Starting Studio");
			LoadAircraft();
			DesignerPartList designerPartList = new DesignerPartList();
			string xml = File.ReadAllText(Game.Instance.GetPathForDocument("DesignerParts.xml"));
			designerPartList.Parts.AddRange(designerPartList.LoadXml(xml));
			foreach (DesignerPart part in designerPartList.Parts)
			{
				_designerParts.Add(part);
			}
			_index = -1;
		}

		protected virtual void Update()
		{
			bool flag = false;
			if (_index == -1)
			{
				_index = StartIndex;
				flag = true;
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
			{
				_index--;
				flag = true;
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
			{
				_index++;
				flag = true;
			}
			if (flag)
			{
				if (_index < 0)
				{
					_index = _designerParts.Count - 1;
				}
				else if (_index >= _designerParts.Count)
				{
					_index = 0;
				}
				DesignerPart designerPart = _designerParts[_index];
				LoadPart(designerPart);
				Debug.Log($"Name: {designerPart.Name}, index: {_index}");
			}
		}

		private IEnumerator RenderPart()
		{
			yield return new WaitForEndOfFrame();
			GameObject gameObject = base.transform.Find("CameraTarget/Camera").gameObject;
			gameObject.transform.LookAt(Vector3.zero);
			if (_cam == null)
			{
				_cam = gameObject.GetComponent<Camera>();
			}
			Camera cam = _cam;
			cam.clearFlags = CameraClearFlags.Color;
			cam.backgroundColor = new Color(0f, 0f, 0f, 0f);
			RenderTexture renderTexture = (cam.targetTexture = RenderTexture.GetTemporary(cam.pixelWidth, cam.pixelHeight, 32, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default, 8));
			cam.Render();
			RenderTexture.active = renderTexture;
			Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, mipChain: false);
			texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
			texture2D.Apply();
			RenderTexture.active = null;
			cam.targetTexture = null;
			RenderTexture.ReleaseTemporary(renderTexture);
			int x = texture2D.width / 2 - 90;
			int y = texture2D.height / 2 - 90;
			Color[] pixels = texture2D.GetPixels(x, y, 180, 180);
			Texture2D texture2D2 = new Texture2D(180, 180, TextureFormat.RGBA32, mipChain: false);
			texture2D2.SetPixels(pixels);
			texture2D2.Apply();
			byte[] bytes = texture2D2.EncodeToPNG();
			DesignerPart designerPart = _designerParts[_index];
			Debug.Log("Rendered Part: " + designerPart.Name);
			string text = (string.IsNullOrEmpty(designerPart.Icon) ? (designerPart.Name + ".png") : (designerPart.Icon + ".png"));
			File.WriteAllBytes("C:\\temp\\PartIcons\\" + text, bytes);
		}
	}
}
