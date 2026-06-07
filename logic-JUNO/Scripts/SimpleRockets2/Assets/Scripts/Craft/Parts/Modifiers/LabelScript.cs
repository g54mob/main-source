using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Scripts.Craft.Parts.Modifiers.Input;
using ModApi;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class LabelScript : PartModifierScript<LabelData>, IFlightUpdate, IGameLoopItem
	{
		private static string _characterWhitelistNormal;

		private static string _characterWhitelistRestricted;

		private BoxCollider _collider;

		private EventMigrator<ICommandPod> _craftControlsChangedMigrator;

		private List<(Match match, IInputControllerInput input, string format)> _inputMatches;

		private TextMeshPro _label;

		private string _whitelist = _characterWhitelistNormal;

		static LabelScript()
		{
			_characterWhitelistNormal = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
			_characterWhitelistRestricted = " !\"$%&'()*+,-./0123456789:<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ\\^_`abcdefghijklmnopqrstuvwxyz|~";
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTMProMeshRebuilt);
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			List<(Match match, IInputControllerInput input, string format)> inputMatches = _inputMatches;
			if (inputMatches != null && inputMatches.Count > 0)
			{
				UpdateLabelText();
			}
		}

		public void OnApplyMaterials()
		{
			List<int> materialIds = base.PartScript.Data.MaterialIds;
			LabelPartGradientType gradient = base.Data.Gradient;
			if (gradient == LabelPartGradientType.None || !base.Data.SupportsGradient)
			{
				_label.enableVertexGradient = false;
				_label.color = new Color32((byte)materialIds[ShiftMaterialIndex(0)], (byte)materialIds[ShiftMaterialIndex(1)], (byte)materialIds[ShiftMaterialIndex(2)], (byte)(base.Data.OutlineWidth * 255f));
			}
			else
			{
				_label.color = Color.white;
				_label.enableVertexGradient = true;
				Color32 color = new Color32((byte)materialIds[ShiftMaterialIndex(0)], (byte)materialIds[ShiftMaterialIndex(1)], (byte)materialIds[ShiftMaterialIndex(2)], (byte)(base.Data.OutlineWidth * 255f));
				VertexGradient colorGradient = new VertexGradient(color, color, color, color);
				float g = (float)(int)(byte)(materialIds[ShiftMaterialIndex(1)] + 128) / 255f;
				switch (gradient)
				{
				case LabelPartGradientType.Vertical:
					colorGradient.bottomLeft.g = g;
					colorGradient.bottomRight.g = g;
					break;
				case LabelPartGradientType.Horizontal:
					colorGradient.topRight.g = g;
					colorGradient.bottomRight.g = g;
					break;
				case LabelPartGradientType.Diagonal:
					colorGradient.topLeft.g = g;
					colorGradient.bottomRight.g = g;
					break;
				case LabelPartGradientType.UpperLeft:
					colorGradient.topLeft.g = g;
					break;
				case LabelPartGradientType.UpperRight:
					colorGradient.topRight.g = g;
					break;
				case LabelPartGradientType.LowerLeft:
					colorGradient.bottomLeft.g = g;
					break;
				case LabelPartGradientType.LowerRight:
					colorGradient.bottomRight.g = g;
					break;
				default:
					throw new NotSupportedException($"Gradient type '{gradient}' not supported.");
				}
				_label.colorGradient = colorGradient;
			}
			_label.SetVerticesDirty();
		}

		private int ShiftMaterialIndex(int index)
		{
			index += base.Data.PaintIndexShift;
			if (index >= base.PartScript.Data.MaterialIds.Count || index < 0)
			{
				Debug.LogWarning($"Label does not have material index {index}");
			}
			return index;
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			if (Game.InFlightScene)
			{
				OnCraftLoadedOrChanged();
			}
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			OnCraftLoadedOrChanged();
		}

		public void OnCurvatureAngleChanged()
		{
			_label.SetVerticesDirty();
			_label.ForceMeshUpdate();
		}

		public void OnDesignerTextChanged(string newVal)
		{
			_label.text = ParseText(newVal, refreshInputs: true);
		}

		public void OnFontChanged(bool updateRenderers = true)
		{
			IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
			switch (base.Data.FontName)
			{
			case "Default":
			case "Liberation Sans":
				_whitelist = _characterWhitelistNormal;
				_label.font = resourceLoader.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");
				break;
			case "Anita Semi Square":
				_whitelist = _characterWhitelistNormal;
				_label.font = resourceLoader.Load<TMP_FontAsset>("Ui/Fonts/AnitaSemiSquare/Anita semi square SDF");
				break;
			case "Roboto":
				_whitelist = _characterWhitelistNormal;
				_label.font = resourceLoader.Load<TMP_FontAsset>("Ui/Fonts/Roboto/PartMaterial-Roboto-Regular SDF");
				break;
			case "Future Earth":
				_whitelist = _characterWhitelistNormal;
				_label.font = resourceLoader.Load<TMP_FontAsset>("Ui/Fonts/FutureEarth/Future Earth SDF");
				break;
			case "Modern 14-Segment":
				_whitelist = _characterWhitelistRestricted;
				_label.font = resourceLoader.Load<TMP_FontAsset>("Ui/Fonts/DSEG-14-Modern/DSEG14Modern-Regular SDF");
				break;
			case "Classic 14-Segment":
				_whitelist = _characterWhitelistRestricted;
				_label.font = resourceLoader.Load<TMP_FontAsset>("Ui/Fonts/DSEG-14-Classic/DSEG14Classic-Regular SDF");
				break;
			case "Stencil":
				_whitelist = _characterWhitelistNormal;
				_label.font = resourceLoader.Load<TMP_FontAsset>("Ui/Fonts/AngkatanBersenjata/AngkatanBersenjata-2OD4o SDF");
				break;
			default:
				throw new NotSupportedException("Font '" + base.Data.FontName + "' not supported");
			}
			if (updateRenderers)
			{
				base.PartScript.PartMaterialScript.UpdateRenderers();
			}
		}

		public void OnGradientChanged()
		{
			base.PartScript.PartMaterialScript.UpdateRenderers();
		}

		public void OnOutlineWidthChanged()
		{
			base.PartScript.PartMaterialScript.UpdateRenderers();
		}

		public override void PrepareForPartIcon()
		{
			base.PrepareForPartIcon();
			Material fontMaterial = Game.Instance.ResourceLoader.LoadMaterial("Craft/Parts/Materials/LabelIconMaterial");
			_label.fontMaterial = fontMaterial;
			_label.color = new Color(1f, 1f, 1f, 1f);
			_label.enableAutoSizing = true;
			_label.SetVerticesDirty();
			_label.ForceMeshUpdate();
		}

		public void UpdateAlignment(TextAlignmentOptions alignment)
		{
			_label.alignment = alignment;
		}

		public void UpdateFontSize(float newVal)
		{
			_label.fontSize = newVal;
			UpdateLabelSize(base.Data.Width, base.Data.Height);
		}

		public void UpdateLabelSize(float width, float height)
		{
			_label.rectTransform.sizeDelta = new Vector2(width * base.Data.FontSize, height * base.Data.FontSize);
			UpdateTextCollider();
			_label.text = string.Empty;
			_label.ForceMeshUpdate();
			UpdateLabelText();
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			Transform transform = base.transform;
			if (!string.IsNullOrEmpty(base.Data.ParentPath))
			{
				transform = transform.Find(base.Data.ParentPath);
				if (transform == null)
				{
					transform = base.transform;
					Debug.LogError($"Label on Part-{base.Data.Part.Id} specifies invalid parent path.");
				}
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Craft/Parts/Prefabs/Label/LabelText"), transform, worldPositionStays: false);
			gameObject.transform.localPosition = base.Data.Offset;
			gameObject.transform.localRotation = Quaternion.Euler(base.Data.Rotation);
			_label = gameObject.GetComponent<TextMeshPro>();
			_collider = GetComponentInChildren<BoxCollider>();
			_craftControlsChangedMigrator = new EventMigrator<ICommandPod>(() => base.PartScript.CommandPod, delegate(ICommandPod commandPod)
			{
				commandPod.ControlsChanged += OnCommandPodControlsChanged;
			}, delegate(ICommandPod commandPod)
			{
				commandPod.ControlsChanged -= OnCommandPodControlsChanged;
			});
			_craftControlsChangedMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
			{
				partScript.CommandPodChanged += migrator.MigrateEvent;
			}, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
			{
				partScript.CommandPodChanged -= migrator.MigrateEvent;
			});
			base.PartScript.MovedToNewCraft += OnMovedToNewCraft;
			OnApplyMaterials();
			UpdateFontSize(base.Data.FontSize);
			UpdateAlignment((TextAlignmentOptions)((int)base.Data.HorizontalAlignment + (int)base.Data.VerticalAlignment));
			OnFontChanged();
			if (Game.InDesignerScene)
			{
				OnDesignerTextChanged(base.Data.DesignText);
			}
			else
			{
				MatchInputs(base.Data.DesignText);
			}
		}

		private static void CurveMesh(Mesh mesh, LabelData label)
		{
			Vector3[] vertices = mesh.vertices;
			Vector3[] normals = mesh.normals;
			bool flag = label.CurvatureDirection == LabelCurvatureDirection.Horizontal;
			float num = (flag ? label.Width : label.Height);
			float num2 = num / 2f;
			float num3 = label.CurvatureAngle / 2f;
			float num4 = num / (num3 * 2f / 360f) / (MathF.PI * 2f);
			Vector3 vector = Vector3.forward * num4;
			float num5 = 1f / num2 * num3 * (MathF.PI / 180f);
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 vector2 = vertices[i];
				float f = (flag ? vector2.x : vector2.y) * num5;
				float num6 = Mathf.Sin(f) * num4;
				float num7 = Mathf.Cos(f) * num4;
				Vector3 vector3 = (vertices[i] = new Vector3(flag ? (vector.x + num6) : vector2.x, flag ? vector2.y : (vector.y + num6), vector.z - num7));
				normals[i] = (new Vector3(flag ? vector3.x : vector.x, flag ? vector.y : vector3.y, vector3.z) - vector).normalized;
			}
			mesh.vertices = vertices;
			mesh.normals = normals;
		}

		private static void OnTMProMeshRebuilt(UnityEngine.Object obj)
		{
			TextMeshPro textMeshPro = obj as TextMeshPro;
			LabelScript labelScript = textMeshPro?.GetComponentInParent<LabelScript>();
			if (!(labelScript == null) && labelScript.Data.CurvatureAngle != 0f)
			{
				CurveMesh(textMeshPro.mesh, labelScript.Data);
				TMP_SubMesh[] componentsInChildren = textMeshPro.GetComponentsInChildren<TMP_SubMesh>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					CurveMesh(componentsInChildren[i].mesh, labelScript.Data);
				}
			}
		}

		private void MatchInputs(string text)
		{
			MatchCollection matchCollection = Regex.Matches(text, "{([^{};]*);?([^{}]*)}");
			_inputMatches = new List<(Match, IInputControllerInput, string)>();
			foreach (Match item in matchCollection)
			{
				IInputControllerInput inputControllerInput = InputControllerInput.Create(item.Groups[1].Value);
				if (inputControllerInput != null)
				{
					_inputMatches.Add((item, inputControllerInput, item.Groups[2].Value));
				}
			}
		}

		private void OnCommandPodControlsChanged(ICommandPod source, bool adjustControlsToCom)
		{
			UpdateInputs();
			UpdateLabelText();
		}

		private void OnCraftLoadedOrChanged()
		{
			UpdateInputs();
			UpdateLabelText();
		}

		private void OnMovedToNewCraft(ICraftScript oldCraft, ICraftScript newCraft)
		{
			UpdateInputs();
			UpdateLabelText();
		}

		private string ParseText(string text, bool refreshInputs = false)
		{
			if (_inputMatches == null || refreshInputs)
			{
				MatchInputs(text);
			}
			foreach (var (match, inputControllerInput, text2) in _inputMatches)
			{
				try
				{
					string text3 = (string.IsNullOrWhiteSpace(text2) ? "0.00" : text2);
					if (Game.InDesignerScene && !string.IsNullOrWhiteSpace(text2))
					{
						0f.ToString(text3);
					}
					text = text.Replace(match.Value, (inputControllerInput == null || !inputControllerInput.Enabled) ? text3 : inputControllerInput.Value.ToString(text3));
				}
				catch (Exception ex)
				{
					text = text.Replace(match.Value, ex.Message);
				}
			}
			return Utilities.ScrubString(text, _whitelist);
		}

		private void UpdateInput(IInputControllerInput input)
		{
			if (input != null)
			{
				if (input is InputControllerInput inputControllerInput)
				{
					inputControllerInput.RefreshInput(base.PartScript);
				}
				else if (input is InputControllerInputPartModifierWrapper inputControllerInputPartModifierWrapper)
				{
					inputControllerInputPartModifierWrapper.RefreshInput(base.PartScript);
				}
				else if (input is InputControllerExpression inputControllerExpression)
				{
					inputControllerExpression.RefreshInput(base.PartScript);
				}
			}
		}

		private void UpdateInputs()
		{
			if (_inputMatches == null)
			{
				return;
			}
			foreach (var inputMatch in _inputMatches)
			{
				IInputControllerInput item = inputMatch.input;
				UpdateInput(item);
			}
		}

		private void UpdateLabelText()
		{
			_label.text = ParseText(base.Data.DesignText);
		}

		private void UpdateTextCollider(bool forceMeshUpdate = true)
		{
			if (_collider != null)
			{
				_collider.transform.localScale = new Vector3(base.Data.FontSize * base.Data.Width, base.Data.FontSize * base.Data.Height, 0.01f);
			}
		}
	}
}
