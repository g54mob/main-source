using System.Collections.Generic;
using System.Linq;
using ModApi;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Planet.CustomData;
using ModApi.Ui.Inspector;
using UnityEngine.UI;

namespace Assets.Scripts.PlanetStudio.Flyouts.CelestialBodyProperties
{
	public class CelestialBodyPropertiesFlyoutScript : PlanetStudioFlyoutScript
	{
		public PlanetDataScript PlanetData => base.PlanetStudioUI.PlanetStudioScript?.CelestialBodyDesignerScript?.CurrentCelestialBody;

		private PlanetAtmosphereData AtmosphereData => PlanetData.AtmosphereData;

		protected override void RefreshUI()
		{
			base.RefreshUI();
			InspectorModel inspectorModel = new InspectorModel("Properties", "Properties");
			GroupModel groupModel = inspectorModel.AddGroup(new GroupModel("Meta-Data"));
			GroupModel groupModel2 = inspectorModel.AddGroup(new GroupModel("Details"));
			GroupModel groupModel3 = inspectorModel.AddGroup(new GroupModel("Terrain Quality Modes"));
			groupModel.AddAndBuild(new TextInputModel("Name", () => PlanetData.Name, delegate(string s)
			{
				PlanetData.Name = s;
			})).Build(delegate(TextInputModel x)
			{
				x.Tooltip = "The name of the celestial body. This is the name that users will see in-game.";
			});
			groupModel.AddAndBuild(new TextInputModel("Version", () => PlanetData.Version.ToString(), delegate(string s)
			{
				PlanetData.Version = Utilities.FormatVersion(s, PlanetData.Version);
			})).Build(delegate(TextInputModel x)
			{
				x.Tooltip = "The version number of the celestial body. This should be in the form of one to four integers separated by periods. You know... like a normal looking version number.";
			});
			groupModel.AddAndBuild(new TextInputModel("Version Tag", () => PlanetData.VersionTag, delegate(string s)
			{
				PlanetData.VersionTag = s;
			})).Build(delegate(TextInputModel x)
			{
				x.Tooltip = "This is an optional field that is typically unused. The game considers celestial bodies with the same author and version tag as part of a set. Celestial bodies may be hidden by default in some lists when a newer version is found (based off the version number). For planetary systems, this is also used to determine newer versions when upgrading saved games to newer versions of the planetary system.";
			});
			groupModel.AddAndBuild(new LabelModel("Description", ElementAlignment.TopLeft)).Build(delegate(LabelModel x)
			{
				x.Tooltip = "The description of the celestial body.";
			});
			TableRowModel tableRowModel = new TableRowModel
			{
				PreferredHeight = 300
			};
			TextInputModel textInputModel = tableRowModel.Add(new TextInputModel(string.Empty, () => PlanetData.Description, delegate(string s)
			{
				PlanetData.Description = s;
			}));
			textInputModel.EnableWordWrapping = true;
			textInputModel.Alignment = ElementAlignment.TopLeft;
			textInputModel.MultiLine = true;
			textInputModel.NavigationMode = Navigation.Mode.None;
			groupModel.Add(tableRowModel);
			TerrainQualityModel qualityModel = new TerrainQualityModel(PlanetData, this);
			groupModel3.Add(new SpinnerModel(() => qualityModel.ModeName, delegate
			{
				qualityModel.Advance(1);
			}, delegate
			{
				qualityModel.Advance(-1);
			})).Tooltip = "The quality mode is determined by the player's quality settings. All quality modes should be configured to provide a good balance of visuals and runtime performance.";
			groupModel3.AddAndBuild(new ToggleModel("Automatic", () => qualityModel.Selected.Automatic, delegate(bool x)
			{
				qualityModel.Selected.Automatic = x;
				if (x)
				{
					qualityModel.UpdateFromTargetDistance();
				}
			})).Build(delegate(ToggleModel x)
			{
				x.DetermineVisibility = () => qualityModel.Exists;
			}).Build(delegate(ToggleModel x)
			{
				x.Tooltip = "Toggles between the choice of manually specifying the specific values for terrain quality or choosing a target resolution and letting the game determine the specific quality settings automatically.";
			});
			groupModel3.AddAndBuild(new NumericInputModel("Target Resolution", () => qualityModel.Selected.TargetVertexDistance, delegate(double x)
			{
				qualityModel.Selected.TargetVertexDistance = x;
				qualityModel.UpdateFromTargetDistance();
			}, 5.0, 10000.0)).Build(delegate(NumericInputModel x)
			{
				x.DetermineVisibility = () => qualityModel.Selected.Automatic && qualityModel.Exists;
			}).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "Enter the desired distance between adjacent vertices and the settings will be automatically adjusted. Lower distances look better, but can greatly reduce runtime performance and increase memory usage and load times.";
			});
			groupModel3.AddAndBuild(new NumericInputModel("Min Subdivisions", () => qualityModel.MinSubdivisionLevel, delegate(double x)
			{
				qualityModel.MinSubdivisionLevel = (int)x;
			}, 1.0, 20.0)).Build(delegate(NumericInputModel x)
			{
				x.DetermineVisibility = () => !qualityModel.Selected.Automatic && qualityModel.Exists;
			}).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "The minimum number of times surface detail will be subdivided. Increasing this number will improve detail when far away from the ground and can greatly reduce performance and increase memory usage and load times.";
			});
			groupModel3.AddAndBuild(new NumericInputModel("Max Subdivisions", () => qualityModel.MaxSubdivisionLevel, delegate(double x)
			{
				qualityModel.MaxSubdivisionLevel = (int)x;
			}, 1.0, 20.0)).Build(delegate(NumericInputModel x)
			{
				x.DetermineVisibility = () => !qualityModel.Selected.Automatic && qualityModel.Exists;
			}).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "The maximum number of times surface detail will be subdivided. Increasing this number will improve detail when close to the ground, but it can greatly reduce performance and increase memory usage and load times.";
			});
			groupModel3.AddAndBuild(new NumericInputModel("Terrain Vertices", () => qualityModel.TerrainQuadEdgeVertexCount, delegate(double x)
			{
				qualityModel.TerrainQuadEdgeVertexCount = (int)x;
			}, 13.0, 29.0)).Build(delegate(NumericInputModel x)
			{
				x.DetermineVisibility = () => !qualityModel.Selected.Automatic && qualityModel.Exists;
			}).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "The number of vertices along one edge of a terrain quad. Higher values look better, but reduce performance and increase memory usage and load times. This value must be odd.";
			});
			EnumDropdownModel<TerrainQualityModel.WaterVertexQualityType> enumDropdownModel = groupModel3.Add(new EnumDropdownModel<TerrainQualityModel.WaterVertexQualityType>("Water Vertices", () => qualityModel.WaterVertexQuality));
			enumDropdownModel.DetermineVisibility = () => !qualityModel.Selected.Automatic && qualityModel.Exists;
			enumDropdownModel.Alignment = ElementAlignment.Right;
			enumDropdownModel.ValueChanged += delegate(TerrainQualityModel.WaterVertexQualityType v, TerrainQualityModel.WaterVertexQualityType old)
			{
				qualityModel.WaterVertexQuality = v;
			};
			enumDropdownModel.Tooltip = "The number of vertices along one edge of a water quad is dependent on the current setting for a terrain quad. They can either use the same number of vertices or half as many. Full looks better, but Half has better performance.";
			groupModel3.AddAndBuild(new TextModel("Estimated Resolution", () => $"{qualityModel.Selected.Quality.GetEstimatedDistanceBetweenVertices(PlanetData.Radius):n3}m")).Build(delegate(TextModel x)
			{
				x.Tooltip = "The estimated distance between adjacent vertices on the terrain geometry at the highest subdivision level as seen when the player is one the ground. Lower distances look better, but can greatly reduce runtime performance and increase memory usage and load times.";
			}).Build(delegate(TextModel x)
			{
				x.DetermineVisibility = () => !qualityModel.Selected.Automatic && qualityModel.Exists;
			});
			groupModel3.AddAndBuild(new LabelModel("QuadSphere Loading Distances", ElementAlignment.BottomLeft)).Build(delegate(LabelModel x)
			{
				x.PreferredHeight = 30;
			}).Build(delegate(LabelModel x)
			{
				x.DetermineVisibility = () => qualityModel.Exists;
			});
			groupModel3.AddAndBuild(new ToggleModel("Automatic", () => qualityModel.AutoQuadSphereDistances, delegate(bool x)
			{
				qualityModel.AutoQuadSphereDistances = x;
				PlanetTerrainQuality quality = qualityModel.Selected.Quality;
				if (x)
				{
					quality.QuadSphereActivationDistance = 0L;
					quality.QuadSphereTransitionDistance = 0L;
				}
				else if (quality.QuadSphereActivationDistance == 0L && quality.QuadSphereTransitionDistance == 0L)
				{
					long quadSphereTransitionDistance = (quality.QuadSphereActivationDistance = (long)(PlanetData.Radius * 2.0));
					quality.QuadSphereTransitionDistance = quadSphereTransitionDistance;
				}
			})).Build(delegate(ToggleModel x)
			{
				x.DetermineVisibility = () => qualityModel.Exists;
			}).Build(delegate(ToggleModel x)
			{
				x.Tooltip = "Toggles between the choice of manually specifying the specific values for quad sphere activation and transition distances or letting the game automatically calculate those values.";
			});
			groupModel3.AddAndBuild(new NumericInputModel("Activation Distance", () => qualityModel.Selected.Quality.QuadSphereActivationDistance, delegate(double x)
			{
				qualityModel.Selected.Quality.QuadSphereActivationDistance = (long)x;
			}, 0.0)).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "The distance from the center of the planet at which the quad sphere terrain is enabled. If this is left at zero, then a default value will be used, which is the diameter of the planet.";
			}).Build(delegate(NumericInputModel x)
			{
				x.DetermineVisibility = () => qualityModel.Exists && !qualityModel.AutoQuadSphereDistances;
			});
			groupModel3.AddAndBuild(new NumericInputModel("Transition Distance", () => qualityModel.Selected.Quality.QuadSphereTransitionDistance, delegate(double x)
			{
				qualityModel.Selected.Quality.QuadSphereTransitionDistance = (long)x;
			}, 0.0)).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "The distance over which the rendering is transitioned between the quad sphere terrain and the scaled space renderer. The quad sphere is 100% visible at the activation distance and the scaled space renderer is 100% visible at the activation distance plus the transition distance. If this is left at zero, then a default value will be used, which is the diameter of the planet.";
			}).Build(delegate(NumericInputModel x)
			{
				x.DetermineVisibility = () => qualityModel.Exists && !qualityModel.AutoQuadSphereDistances;
			});
			groupModel3.Add(new TextButtonModel("Create", delegate
			{
				qualityModel.CreateMode();
			}, null, () => !qualityModel.Exists)).Style = ButtonModel.ButtonStyle.Primary;
			groupModel3.Add(new TextButtonModel("Delete", delegate
			{
				qualityModel.DeleteMode();
			}, null, () => qualityModel.CanDelete));
			string autoUpdateGravityKeyName = "PlanetStudio.AutoUpdateGravity";
			groupModel2.AddAndBuild(new NumericInputModel("Radius", () => PlanetData.Radius, delegate(double x)
			{
				double num = PlanetData.Mass / MathUtils.CalculateVolumeOfSphere(PlanetData.Radius);
				PlanetData.Radius = x;
				if (Game.Instance.Settings.UserPrefs.GetBool(autoUpdateGravityKeyName, defaultValue: true))
				{
					double num2 = MathUtils.CalculateVolumeOfSphere(PlanetData.Radius);
					PlanetData.SurfaceGravity = 6.67384E-11 * num2 * num / (x * x);
				}
				PlanetData.CalculateMass();
				AtmosphereData.RecalculateDependentParameters(PlanetData.SurfaceGravity);
			}, 1000.0)).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "The radius of the celestial body in meters.";
			});
			groupModel2.AddAndBuild(new ToggleModel("Auto Update Gravity", () => Game.Instance.Settings.UserPrefs.GetBool(autoUpdateGravityKeyName, defaultValue: true), delegate(bool x)
			{
				Game.Instance.Settings.UserPrefs.SetBool(autoUpdateGravityKeyName, x);
			})).Build(delegate(ToggleModel x)
			{
				x.Tooltip = "Automatically update the surface gravity when the radius changes.";
			});
			groupModel2.AddAndBuild(new NumericInputModel("Surface Gravity", () => PlanetData.SurfaceGravity, delegate(double x)
			{
				PlanetData.SurfaceGravity = x;
				AtmosphereData.RecalculateDependentParameters(x);
			}, 0.009999999776482582, 250.0)).Build(delegate(NumericInputModel x)
			{
				x.Tooltip = "The surface gravity of the celestial body in meters per second squared.";
			});
			_ = groupModel2.AddAndBuild(new ToggleModel("Fade Skybox During Daytime", () => PlanetData.SkyboxFadeDuringDaytime, delegate(bool x)
			{
				PlanetData.SkyboxFadeDuringDaytime = x;
			})).Build(delegate(ToggleModel x)
			{
				x.Tooltip = "If true, the skybox will be faded out during the daytime.";
			}).Model;
			groupModel2.AddAndBuild(new ToggleModel("Has Terrain Physics", () => PlanetData.HasTerrainPhysics, delegate(bool x)
			{
				PlanetData.HasTerrainPhysics = x;
			})).Build(delegate(ToggleModel x)
			{
				x.Tooltip = "If true, the celestial body will have terrain physics. Typically, you always want this, however it is something you may want to disable for gas giant type planets where you can never actually reach the surface.";
			});
			List<string> modKeywords = PlanetData.ModKeywords;
			List<string> list = CustomPlanetModKeywords.RegisteredKeywords.Where((string x) => CustomPlanetModKeywords.ShowInPlanetStudio(x)).ToList();
			GroupModel modKeywordsGroup;
			if (modKeywords.Count > 0 || list.Count > 0)
			{
				modKeywordsGroup = inspectorModel.AddGroup(new GroupModel("Mod Keywords"));
				foreach (string item in list)
				{
					AddKeywordToggleModel(item);
				}
				foreach (string item2 in modKeywords)
				{
					if (!CustomPlanetModKeywords.IsRegistered(item2))
					{
						AddKeywordToggleModel(item2);
					}
				}
			}
			BuildFromModel(inspectorModel);
			void AddKeywordToggleModel(string keyword)
			{
				modKeywordsGroup.AddAndBuild(new ToggleModel(keyword, () => PlanetData.ModKeywords.Contains(keyword), delegate(bool x)
				{
					UpdateModKeyword(keyword, x);
				}, "Enable or disable this mod keyword for this celestial body. How this keyword is used is entirely dependent on the mod using it."));
			}
			void UpdateModKeyword(string keyword, bool keywordEnabled)
			{
				List<string> modKeywords2 = PlanetData.ModKeywords;
				if (keywordEnabled && !modKeywords2.Contains(keyword))
				{
					modKeywords2.Add(keyword);
				}
				else if (!keywordEnabled && modKeywords2.Contains(keyword))
				{
					modKeywords2.Remove(keyword);
				}
			}
		}
	}
}
