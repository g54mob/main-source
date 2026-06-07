using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.PlanetStudio.Flyouts;
using ModApi;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.Settings;
using ModApi.State;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.PlanetObjects
{
	public class SubStructureObject : IPlanetObject
	{
		private PlanetDataScript _body;

		public bool CanDragInTreeView => true;

		public bool Collapsed
		{
			get
			{
				return SubStructure.Collapsed;
			}
			set
			{
				SubStructure.Collapsed = value;
			}
		}

		public string Icon => null;

		public bool IsLoadedInGameView => SubStructure.LoadedGameObject != null;

		public string Name
		{
			get
			{
				return SubStructure.Name;
			}
			set
			{
				SubStructure.Name = value;
			}
		}

		public Vector3d PlanetPosition
		{
			get
			{
				if (IsLoadedInGameView)
				{
					return ReferenceFrame.FrameToPlanetPosition(SubStructure.LoadedGameObject.transform.position);
				}
				StructureNodeData structureNodeData = SubStructure.StructureNodeData;
				IPlanetNode planetNode = Flyout.CelestialBodyViewer.PlanetScript.PlanetNode;
				Vector3d surfacePosition = planetNode.GetSurfacePosition(structureNodeData.Latitude * 0.01745329, structureNodeData.Longitude * 0.01745329, AltitudeType.AboveGroundLevel, structureNodeData.Elevation);
				return planetNode.SurfaceVectorToPlanetVector(surfacePosition);
			}
		}

		public IReferenceFrame ReferenceFrame => Flyout.CelestialBodyViewer.ReferenceFrame;

		public StructureObject RootStructureObject { get; }

		public SubStructure SubStructure { get; }

		public string TypeName => "Sub-Structure";

		protected PlanetObjectsFlyoutScript Flyout { get; }

		public SubStructureObject(SubStructure subStructure, PlanetObjectsFlyoutScript flyout, StructureObject rootStructureObject)
		{
			SubStructure = subStructure;
			Flyout = flyout;
			RootStructureObject = rootStructureObject;
			_body = Flyout.Designer.CurrentCelestialBody;
		}

		public static bool HandleDropSubStructureInTreeView(ISubStructureParent parent, Transform parentTransform, IPlanetObject planetObject, IPlanetObject insertBefore, PlanetObjectsFlyoutScript flyout)
		{
			if (planetObject is SubStructureObject subStructureObject)
			{
				subStructureObject.SubStructure.SetParent(parent, (insertBefore as SubStructureObject)?.SubStructure);
				Transform transform = subStructureObject.SubStructure.LoadedGameObject?.transform;
				if (transform != null && parentTransform != null)
				{
					transform.SetParent(parentTransform, worldPositionStays: true);
					flyout.OnObjectMovedExternally(subStructureObject);
					subStructureObject.SubStructure.LocalPosition = transform.localPosition;
					subStructureObject.SubStructure.LocalScale = transform.localScale;
					subStructureObject.SubStructure.LocalRotation = transform.localRotation.eulerAngles;
					subStructureObject.SubStructure.UpdateDynamicMaterials();
				}
				DestroySubStructureGameObjects(subStructureObject.SubStructure);
				flyout.RefreshStructureGameObjects(parent.StructureNodeData);
				flyout.OnObjectMovedExternally(planetObject);
				return true;
			}
			return false;
		}

		public void Delete(PlanetDataScript planetData, CelestialBodyViewerScript viewer)
		{
			DestroySubStructureGameObjects(SubStructure);
			SubStructure.SetParent(null, null);
		}

		public void GenerateModel(InspectorModel model, Action refreshUI)
		{
			Action<object> update = delegate
			{
				Transform transform = SubStructure.LoadedGameObject?.transform;
				if (transform != null)
				{
					transform.SetLocalPositionAndRotation(SubStructure.LocalPosition, Quaternion.Euler(SubStructure.LocalRotation));
					transform.localScale = SubStructure.LocalScale;
					Flyout.OnObjectMovedExternally(this);
				}
			};
			model.Add(new Vector3InputModel("Local Position", () => SubStructure.LocalPosition, delegate(Vector3 x)
			{
				Action<object> action = update;
				Vector3 vector = (SubStructure.LocalPosition = x);
				action(vector);
			}));
			model.Add(new Vector3InputModel("Local Rotation", () => SubStructure.LocalRotation, delegate(Vector3 x)
			{
				Action<object> action = update;
				Vector3 vector = (SubStructure.LocalRotation = x);
				action(vector);
			}));
			model.Add(new Vector3InputModel("Local Scale", () => SubStructure.LocalScale, delegate(Vector3 x)
			{
				Action<object> action = update;
				Vector3 vector = (SubStructure.LocalScale = x);
				action(vector);
				SubStructure.UpdateDynamicMaterials();
				RootStructureObject.FixNegativeBoxColliderScales();
			}));
			model.Add(new Vector3InputModel("Angular Velocity", () => SubStructure.AngularVelocity ?? Vector3.zero, delegate(Vector3 x)
			{
				Action<object> action = update;
				Vector3? vector = (SubStructure.AngularVelocity = x);
				action(vector);
			}));
			if (SubStructure.Color.HasValue)
			{
				model.Add(new ColorModel("Color", () => SubStructure.Color.Value, delegate(Color x)
				{
					SubStructure.Color = x;
					SubStructure.UpdateDynamicMaterials();
				}, allowTransparency: false, callbackOnPreviewColorChange: true));
			}
			if (SubStructure.Tiling.HasValue)
			{
				model.Add(new SliderModel("Texture Tiling", () => SubStructure.Tiling.Value, delegate(float x)
				{
					SubStructure.Tiling = x;
					SubStructure.UpdateDynamicMaterials();
				}, 0f, 2f)).ValueFormatter = (float x) => x.ToString();
			}
			model.Add(new NumericInputModel("Level of Detail", () => SubStructure.LevelOfDetail, delegate(double x)
			{
				SubStructure.LevelOfDetail = (int)x;
				RootStructureObject.RefreshLevelOfDetail();
			}, 0.0, SubStructure.StructureNodeData.LodDistanceScalars.Length, (double x) => ((int)x).ToString())).Tooltip = "The minimum level of detail that the sub-structure should be loaded. Zero indicates it should be loaded immediately with the top level structure. Values above zero indicate it should be loaded at the coresponding level of detail, which are defined in the top level structure. Generally, large objects should be in a lower LOD and smaller objects should bein a higher LOD.";
			string text = (model.Add(new NumericInputModel("Mass", () => SubStructure.Mass, delegate(double x)
			{
				SubStructure.Mass = x;
			}, 0.0)).Tooltip = "To make this sub-structure (and its children) a dynamic object, change this mass to a non-zero value. Children objects will contribute to the overall mass and can affect the CoM of the structure. If zero (the default) then the sub-structure will be a static, immovable object. Note that dynamic objects will be reset when the player resumes flight, quick loads, or returns to the location after leaving the structure's LOD distance, so use with caution.");
			model.Add(new EnumDropdownModel<TerrainQualitySettings.StructureDetailQuality>("Required Quality", () => SubStructure.RequiredQuality, "The minimum required quality to load this sub-structure (and its children).")).ValueChanged += delegate(TerrainQualitySettings.StructureDetailQuality newVal, TerrainQualitySettings.StructureDetailQuality oldVal)
			{
				SubStructure.RequiredQuality = newVal;
			};
			if (Device.IsUnityEditor)
			{
				model.Add(new EnumDropdownModel<SubStructure.CameraCollisionType>("Camera Collision", () => SubStructure.CameraCollision, "Force or prevent camera collision. Default is recommended and this should only be changed in dire circumstances as it can have unintended consequences.")).ValueChanged += delegate(SubStructure.CameraCollisionType newVal, SubStructure.CameraCollisionType oldVal)
				{
					SubStructure.CameraCollision = newVal;
				};
			}
			if (!(SubStructure.LoadedGameObject != null))
			{
				return;
			}
			if (Device.IsUnityEditor)
			{
				TextButtonModel item = new TextButtonModel("Export Mesh", delegate
				{
					GameObject loadedGameObject = SubStructure.LoadedGameObject;
					if (loadedGameObject != null)
					{
						Vector3 position = loadedGameObject.transform.position;
						Quaternion rotation = loadedGameObject.transform.rotation;
						loadedGameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
						string text3 = Utilities.CombinePaths(Game.PersistentDataPath, Utilities.ScrubFileName(Name) + ".stl");
						List<GameObject> list = new List<GameObject>();
						GetGameObjectsFromHierarchy(loadedGameObject.gameObject, list);
						STL.Export(list.ToArray(), text3);
						loadedGameObject.transform.SetPositionAndRotation(position, rotation);
						Debug.Log("Mesh exported to :" + text3);
						Flyout.PlanetStudioUI.ShowMessage("Sub-Structure Exported to " + text3);
					}
					else
					{
						Flyout.PlanetStudioUI.ShowMessage("Cannot export sub-structure because it is not loaded. Move the camera closer to it.");
					}
				});
				model.Add(item);
			}
			if (SubStructure.LoadedGameObject.GetComponentsInChildren<StructureLaunchLocationInfoScript>().Length == 0)
			{
				return;
			}
			TextButtonModel item2 = new TextButtonModel("Update Launch Locations", delegate
			{
				CelestialBodyViewerScript celestialBodyViewer = Flyout.CelestialBodyViewer;
				if (SubStructure.LoadedGameObject != null)
				{
					IPlanetNode planetNode = celestialBodyViewer.PlanetScript.PlanetNode;
					StructureNode structureNode = (from x in celestialBodyViewer.GameViewObjects
						select x as StructureNode into x
						where x?.Data == SubStructure.StructureNodeData
						select x).FirstOrDefault();
					int num = 0;
					int num2 = 0;
					StructureLaunchLocationInfoScript[] componentsInChildren = SubStructure.LoadedGameObject.GetComponentsInChildren<StructureLaunchLocationInfoScript>(includeInactive: true);
					foreach (StructureLaunchLocationInfoScript structureLaunchLocationInfoScript in componentsInChildren)
					{
						Vector3d vector3d = celestialBodyViewer.ReferenceFrame.FrameToPlanetPosition(structureLaunchLocationInfoScript.transform.position);
						Vector3d surfacePosition = celestialBodyViewer.PlanetScript.PlanetNode.PlanetVectorToSurfaceVector(vector3d);
						planetNode.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
						double num4 = planetNode.GetTerrainHeight(vector3d);
						if (planetNode.PlanetData.HasWater && num4 < (double)planetNode.PlanetData.SeaLevel)
						{
							num4 = planetNode.PlanetData.SeaLevel;
						}
						float y = (Quaternion.Inverse(structureNode.Transform.rotation) * structureLaunchLocationInfoScript.transform.rotation).eulerAngles.y;
						double altitudeAboveGroundLevel = vector3d.magnitude - (planetNode.PlanetData.Radius + num4);
						LaunchLocation launchLocation = new LaunchLocation(structureLaunchLocationInfoScript.Name, LaunchLocationType.SurfaceLockedGround, planetNode.Name, latitude * 57.295780181884766, longitude * 57.295780181884766, Vector3d.zero, structureLaunchLocationInfoScript.Heading + SubStructure.StructureNodeData.Heading + (double)y, altitudeAboveGroundLevel);
						LaunchLocation launchLocation2 = celestialBodyViewer.CelestialBodyData.DefaultLaunchLocations.Where((LaunchLocation x) => x.Name == launchLocation.Name).FirstOrDefault();
						if (launchLocation2 != null)
						{
							celestialBodyViewer.CelestialBodyData.DefaultLaunchLocations.Remove(launchLocation2);
							num2++;
						}
						else
						{
							num++;
						}
						celestialBodyViewer.CelestialBodyData.DefaultLaunchLocations.Add(launchLocation);
					}
					refreshUI();
					Game.Instance.UserInterface.CreateMessageDialog($"Added {num} new locations and updated {num2} existing locations.");
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog("Sub-structure must be loaded and in view to update its launch locations. Zoom in closer and try again.");
				}
			});
			model.Add(item2);
		}

		public Quaternion GetMoveToolRotation(IReferenceFrame referenceFrame, IPlanetNode planetNode)
		{
			return SubStructure.LoadedGameObject?.transform?.rotation ?? Quaternion.identity;
		}

		public virtual bool OnReceiveDropInTreeView(IPlanetObject planetObject, IPlanetObject insertBefore)
		{
			return HandleDropSubStructureInTreeView(SubStructure, SubStructure.LoadedGameObject?.transform, planetObject, insertBefore, Flyout);
		}

		public void SetPlanetPosition(Vector3d p, bool adjustElevation)
		{
			Transform transform = SubStructure.LoadedGameObject?.transform;
			if (transform != null)
			{
				Vector3 position = ReferenceFrame.PlanetToFramePosition(p);
				transform.position = position;
				SubStructure.LocalPosition = transform.localPosition;
			}
		}

		public void UpdateGameViewObject(CelestialBodyViewerScript viewer)
		{
		}

		private static void DestroySubStructureGameObjects(SubStructure subStructure)
		{
			if (subStructure.LoadedGameObject != null)
			{
				UnityEngine.Object.Destroy(subStructure.LoadedGameObject);
				subStructure.OnGameObjectUnloaded();
			}
			foreach (SubStructure subStructure2 in subStructure.SubStructures)
			{
				DestroySubStructureGameObjects(subStructure2);
			}
		}

		private static void GetGameObjectsFromHierarchy(GameObject g, List<GameObject> list)
		{
			if (!(g != null))
			{
				return;
			}
			list.Add(g);
			foreach (Transform item in g.transform)
			{
				GetGameObjectsFromHierarchy(item.gameObject, list);
			}
		}
	}
}
