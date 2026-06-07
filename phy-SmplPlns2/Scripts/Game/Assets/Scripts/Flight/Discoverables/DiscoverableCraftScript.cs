using System.Collections;
using System.IO;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.UI;
using Assets.Scripts.Settings;
using Assets.Scripts.UI;
using Jundroo.Common.Extensions;
using Jundroo.Common.Math;
using Lightbug.CharacterControllerPro.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.Discoverables
{
	public class DiscoverableCraftScript : DiscoverableAreaScript
	{
		private bool _canDiscover;

		private bool _couldDiscoverLastFrame;

		[SerializeField]
		private string _craftId;

		[SerializeField]
		private Vector3 _craftModelOffset = Vector3.up;

		[SerializeField]
		private GameObject _disableWhenDiscovered;

		[SerializeField]
		private GameObject _enableWhenDiscovered;

		[SerializeField]
		private Image _image;

		private Material _imageMaterial;

		[SerializeField]
		private TMP_Text[] _infoTexts;

		private string CraftFilePath => Path.Combine("Stock Craft", _craftId + ".xml");

		protected override void Awake()
		{
			base.Awake();
			if (Game.Instance.CraftDatabase.TryGetCraft(CraftFilePath, out var craftFileInfo))
			{
				CraftSettings crafts = Game.Instance.Settings.Cloud.Crafts;
				string newValue = "01";
				string newValue2 = "000";
				string newValue3 = "0000";
				string newValue4 = "000";
				string newValue5 = "000";
				string newValue6 = "00";
				string newValue7 = "00000";
				string newValue8 = "00000";
				string newValue9 = "0000";
				string newValue10 = "00.0";
				string newValue11 = "0000";
				if (craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.PartCount, out var value))
				{
					newValue2 = value.ToString("000");
				}
				if (craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.PerformanceCost, out var value2))
				{
					newValue3 = value2.ToString("0000");
				}
				if (craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.Length, out var value3))
				{
					newValue4 = value3.Format(UnitType.ShortDistance, solo: true, longName: false, "n2");
				}
				if (craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.WingSpan, out var value4))
				{
					newValue5 = value4.Format(UnitType.ShortDistance, solo: true, longName: false, "n2");
				}
				if (craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.Height, out var value5))
				{
					newValue6 = value5.Format(UnitType.ShortDistance, solo: true, longName: false, "n2");
				}
				if (craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.EmptyWeight, out var value6))
				{
					newValue7 = value6.Format(UnitType.Mass, solo: true, longName: false, "n1");
				}
				if (craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.LoadedWeight, out var value7))
				{
					newValue8 = value7.Format(UnitType.Mass, solo: true, longName: false, "n1");
				}
				if (craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.FuelAmount, out var value8))
				{
					newValue9 = value8.Format(UnitType.Volume, solo: true, longName: true, "n");
				}
				if (craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.Drag, out var value9))
				{
					newValue11 = value9.ToString("n");
				}
				float value10 = -1f;
				float value11 = -1f;
				craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.PowerToWeightRatio, out value10);
				craftFileInfo.Stats.TryGetValue(AircraftScript.AircraftStats.HorsePowerToWeightRatio, out value11);
				if (value10 > 0f || value11 > 0f)
				{
					newValue10 = Mathf.Max(value10, value11).ToString("00.0");
				}
				TMP_Text[] infoTexts = _infoTexts;
				foreach (TMP_Text obj in infoTexts)
				{
					obj.text = obj.text.Replace("{index}", (crafts.GetDiscoverableIndex(_craftId) + 1).ToString("D2")).Replace("{craftsTotal}", crafts.DiscoverableCount.ToString("D2")).Replace("{name}", craftFileInfo.Name)
						.Replace("{crew}", newValue)
						.Replace("{partCount}", newValue2)
						.Replace("{perfCost}", newValue3)
						.Replace("{length}", newValue4)
						.Replace("{width}", newValue5)
						.Replace("{height}", newValue6)
						.Replace("{massDry}", newValue7)
						.Replace("{massWet}", newValue8)
						.Replace("{fuel}", newValue9)
						.Replace("{pow2weight}", newValue10)
						.Replace("{drag}", newValue11)
						.Replace("{dist}", Units.CurrentUnitSystem.Units[UnitType.ShortDistance].Abbreviation)
						.Replace("{mass}", Units.CurrentUnitSystem.Units[UnitType.Mass].Abbreviation)
						.Replace("{vol}", Units.CurrentUnitSystem.Units[UnitType.Volume].Abbreviation);
				}
				Texture texture = Resources.Load<Texture>("Flight/Discoverable/Pictures/" + _craftId);
				if (texture != null)
				{
					_imageMaterial = Object.Instantiate(_image.material);
					_imageMaterial.SetTexture("_BaseMap", texture);
					_image.material = _imageMaterial;
				}
			}
			base.Discovered = Game.Instance.Settings.Cloud.Crafts.HasDiscoveredCraft(_craftId);
			base.gameObject.SetActive(!base.Discovered && Game.Instance.CurrentLevel.IsSandbox);
			_disableWhenDiscovered.SetActive(!base.Discovered && Game.Instance.CurrentLevel.IsSandbox);
			_enableWhenDiscovered.SetActive(base.Discovered && Game.Instance.CurrentLevel.IsSandbox);
		}

		protected void OnDestroy()
		{
			Object.Destroy(_imageMaterial);
			if (FlightSceneScript.Instance?.FlightUI != null)
			{
				FlightSceneScript.Instance.FlightUI.GrabBlueprintButtonClicked -= OnGrabBlueprintButtonClicked;
			}
		}

		protected override void OnDiscovered()
		{
			base.Discovered = true;
			CloudSettings cloud = Game.Instance.Settings.Cloud;
			CraftSettings crafts = cloud.Crafts;
			string arg = "Invalid Craft";
			if (Game.Instance.CraftDatabase.TryGetCraft(CraftFilePath, out var craftFileInfo))
			{
				arg = craftFileInfo.Name;
			}
			else
			{
				Debug.LogError("Could not find craft for discovery '" + _craftId + "'", this);
			}
			crafts.UnlockDiscoverableCraft(_craftId);
			cloud.SaveIfNecessary();
			_disableWhenDiscovered.GetComponent<AudioSource>()?.Stop();
			Game.Instance.UserInterface.Sound.PlaySound(UISound.DiscoverLocation);
			FlightSceneScript.Instance.FlightUI.ShowLogMessage($"You unlocked the {arg}!\n{crafts.DiscoveredCount}/{crafts.DiscoverableCount} Hidden Crafts");
			if (craftFileInfo != null)
			{
				LoadCraft(craftFileInfo);
			}
		}

		protected override void PlayerInBounds(FlightScenePlayer player)
		{
			AircraftScript aircraft = player.Aircraft;
			CharacterActor characterActor = player.CharacterActor;
			float num = 0f;
			if (base.MustBeStopped)
			{
				if (base.ParentRigidBody != null)
				{
					if (aircraft != null)
					{
						num = (aircraft.Velocity - base.ParentRigidBody.linearVelocity).magnitude;
					}
					else if (characterActor != null)
					{
						num = (characterActor.Velocity - base.ParentRigidBody.linearVelocity).magnitude;
					}
				}
				else
				{
					num = aircraft?.AirSpeed ?? characterActor.Velocity.magnitude;
				}
			}
			_canDiscover = (!base.MustBeStopped || num <= 2f) && (!base.MustNotHaveCriticalDamage || !aircraft.CriticallyDamaged);
		}

		protected override void Update()
		{
			_couldDiscoverLastFrame = _canDiscover;
			_canDiscover = false;
			base.Update();
			if (_canDiscover)
			{
				FlightSceneScript.Instance.FlightUI.SetActionMode(FlightUIScript.ActionButtonMode.GrabBlueprint);
				if (!_couldDiscoverLastFrame)
				{
					FlightSceneScript.Instance.FlightUI.GrabBlueprintButtonClicked += OnGrabBlueprintButtonClicked;
				}
				if (Game.Inputs.Interact.GetButtonDownIfEnabled())
				{
					OnDiscovered();
				}
			}
			else if (_couldDiscoverLastFrame)
			{
				FlightSceneScript.Instance.FlightUI.SetActionMode(FlightUIScript.ActionButtonMode.Hidden);
				FlightSceneScript.Instance.FlightUI.GrabBlueprintButtonClicked -= OnGrabBlueprintButtonClicked;
			}
		}

		private IEnumerator AnimateThenVanishCraft(Transform craft, Vector3 startScale, Vector3 startPosition, Vector3 targetScale, Vector3 targetPosition)
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			FlightScenePlayer localPlayer = FlightSceneScript.Instance.LocalPlayer;
			float spinTime = Time.time + 10f;
			float lerpTime = 0f;
			craft.localScale = startScale;
			craft.localPosition = startPosition;
			while (Time.time < spinTime)
			{
				yield return new WaitForEndOfFrame();
				craft.localEulerAngles += 36.5f * Time.deltaTime * Vector3.up;
				if (lerpTime < 1f)
				{
					lerpTime += Time.deltaTime * 0.5f;
					craft.localScale = Vector3.Lerp(craft.localScale, targetScale, lerpTime);
					craft.localPosition = Vector3.Lerp(craft.localPosition, targetPosition, lerpTime);
				}
				if (localPlayer != null && IsPlayerInBounds(localPlayer))
				{
					spinTime = Time.time + 10f;
				}
			}
			lerpTime = 0f;
			while (lerpTime < 1f)
			{
				yield return new WaitForEndOfFrame();
				craft.localEulerAngles += 36.5f * Time.deltaTime * Vector3.up;
				lerpTime += Time.deltaTime;
				craft.localScale = Vector3.Lerp(targetScale, Vector3.zero, lerpTime);
				craft.localPosition = Vector3.Lerp(targetPosition, startPosition, lerpTime);
			}
			Object.Destroy(craft.gameObject);
		}

		private void LoadCraft(CraftFileInfo craftFile)
		{
			AircraftData aircraftData = new AircraftData(craftFile.LoadXml(showErrorDialogs: false), CraftLoadContext.Menu);
			PartData.PartCreationInfo partCreationInfo = new PartData.PartCreationInfo();
			partCreationInfo.CreateHingeJoints = false;
			partCreationInfo.IsRigidBodyKinematic = true;
			partCreationInfo.CreateRigidBody = false;
			partCreationInfo.EnableWingScript = false;
			float num = Mathf.Max(aircraftData.Size.x, aircraftData.Size.y, aircraftData.Size.z);
			float num2 = Mathf.Pow(num / 25f, 0.5f) / num;
			foreach (PartData disabledPart in aircraftData.Assembly.DisabledParts)
			{
				if (disabledPart.TryGetModifier<DecalData>(out var result) && !(result is TextDecalData))
				{
					result.Width *= num2;
					result.Height *= num2;
				}
			}
			GameObject gameObject = AircraftData.GenerateGameObject(aircraftData, partCreationInfo, 0);
			gameObject.SetLayer(25);
			gameObject.transform.SetParent(base.transform.parent, worldPositionStays: false);
			gameObject.transform.SetLocalPositionAndRotation(Vector3.down * 200f, Quaternion.identity);
			AircraftScript component = gameObject.GetComponent<AircraftScript>();
			Vector3 centerOfMass = component.CenterOfMass.CenterOfMass;
			component.Children.localPosition = new Vector3(0f - centerOfMass.x, 0f - centerOfMass.y, 0f - centerOfMass.z);
			StartCoroutine(AnimateThenVanishCraft(targetPosition: new Vector3(_craftModelOffset.x, (centerOfMass.y - aircraftData.BoundsMinimum.y) * num2 + _craftModelOffset.y, _craftModelOffset.z), craft: gameObject.transform, startScale: Vector3.zero, startPosition: Vector3.zero, targetScale: new Vector3(num2, num2, num2)));
		}

		private void OnGrabBlueprintButtonClicked()
		{
			if (_canDiscover)
			{
				OnDiscovered();
			}
		}

		[ContextMenu("Test Spawn Craft")]
		private void TestSpawnCraft()
		{
			if (!base.gameObject.activeSelf)
			{
				base.gameObject.SetActive(value: true);
			}
			if (Game.Instance.CraftDatabase.TryGetCraft(CraftFilePath, out var craftFileInfo))
			{
				Game.Instance.UserInterface.Sound.PlaySound(UISound.DiscoverLocation);
				LoadCraft(craftFileInfo);
			}
		}
	}
}
