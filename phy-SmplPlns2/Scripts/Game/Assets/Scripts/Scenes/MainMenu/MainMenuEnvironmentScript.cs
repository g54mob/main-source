using System;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.CraftFiles;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Environment;
using Assets.Scripts.Flight;
using DG.Tweening;
using Enviro;
using UnityEngine;

namespace Assets.Scripts.Scenes.MainMenu
{
	public class MainMenuEnvironmentScript : MonoBehaviour
	{
		[SerializeField]
		private Transform _cameraTransform;

		[SerializeField]
		private Transform _carrier;

		[SerializeField]
		private Transform _craftContainer;

		public IEnvironment Environment { get; private set; }

		protected virtual void Awake()
		{
			Environment = new VolumetricEnvironment(EnviroManager.instance);
			PauseManager.Reset();
		}

		protected virtual void OnDestroy()
		{
			Environment.Dispose();
			CraftDatabase craftDatabase = Game.Instance.CraftDatabase;
			if (craftDatabase != null)
			{
				craftDatabase.Initialized -= OnCraftDatabaseInitialized;
			}
		}

		protected virtual void Start()
		{
			LoadAircraft();
			_cameraTransform.localPosition = new Vector3(0f, 0f, -250f);
			_cameraTransform.DOLocalMoveZ(0f, 3f).SetLink(base.gameObject).SetEase(Ease.OutQuart)
				.SetDelay(0.1f)
				.OnComplete(delegate
				{
					StartCarrierRocking();
				});
		}

		private void LoadAircraft()
		{
			CraftDatabase craftDatabase = Game.Instance.CraftDatabase;
			if (!craftDatabase.IsInitialized)
			{
				craftDatabase.Initialized += OnCraftDatabaseInitialized;
				return;
			}
			XElement xElement = craftDatabase.LoadCraftXml("__editor__.xml", showErrorDialogs: false);
			if (xElement == null)
			{
				xElement = craftDatabase.GetCrafts().First().LoadXml(showErrorDialogs: false);
				craftDatabase.SaveCraft("__editor__.xml", xElement, backupPreviousFile: false, updateXmlVersion: false);
			}
			AircraftData aircraftData = new AircraftData(xElement, CraftLoadContext.Menu);
			PartData.PartCreationInfo partCreationInfo = new PartData.PartCreationInfo();
			partCreationInfo.CreateHingeJoints = false;
			partCreationInfo.IsRigidBodyKinematic = true;
			partCreationInfo.CreateRigidBody = false;
			partCreationInfo.EnableWingScript = false;
			GameObject obj = AircraftData.GenerateGameObject(aircraftData, partCreationInfo, 0);
			obj.transform.SetParent(_craftContainer, worldPositionStays: false);
			obj.transform.localPosition = new Vector3(0f, 0f - aircraftData.BoundsMinimum.y, 0f);
			obj.transform.localRotation = Quaternion.identity;
		}

		private void OnCraftDatabaseInitialized(object sender, EventArgs e)
		{
			CraftDatabase craftDatabase = Game.Instance.CraftDatabase;
			if (craftDatabase != null)
			{
				craftDatabase.Initialized -= OnCraftDatabaseInitialized;
			}
			LoadAircraft();
		}

		private void StartCarrierRocking()
		{
			float animationAngle = 2f;
			float animationDuration = 5f;
			_carrier.localEulerAngles = new Vector3(0f, 0f, 0f);
			_carrier.DOLocalRotate(new Vector3(0f, 0f, animationAngle), animationDuration / 2f).SetLink(base.gameObject).SetEase(Ease.InOutSine)
				.OnComplete(delegate
				{
					_carrier.DOLocalRotate(new Vector3(0f, 0f, 0f - animationAngle), animationDuration).SetLink(base.gameObject).SetEase(Ease.InOutSine)
						.SetLoops(-1, LoopType.Yoyo);
				});
		}
	}
}
