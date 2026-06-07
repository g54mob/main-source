using System;
using System.IO;
using Assets.Scripts.State;
using ModApi;
using ModApi.CelestialData;
using ModApi.Services.Purchasing;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Sharing.Handlers.Sandbox
{
	public class SandboxDownload : IRequestHandler
	{
		public class SandboxAlreadyExistsException : Exception
		{
		}

		private byte[] _sandboxBytes;

		private string _sandboxUrlId;

		public string Endpoint => $"/Client/DownloadSandbox?id={_sandboxUrlId}";

		public bool ExpectClientResponse => false;

		public WWWForm Form { get; private set; }

		public string GameStateId { get; private set; }

		public bool IncludeClientData { get; }

		public string SandboxUrlId => _sandboxUrlId;

		public SandboxDownload(string sandboxUrlId)
		{
			_sandboxUrlId = sandboxUrlId;
		}

		public void OnCanceled(WebsiteRequest websiteRequest)
		{
		}

		public void OnComplete(WebsiteRequest request)
		{
			if (request.Success)
			{
				_sandboxBytes = request.ResponseBytes;
			}
		}

		public bool SaveSandbox(bool overwriteExisting, out string gameStateId, out string error)
		{
			bool result = SaveSandbox(_sandboxBytes, overwriteExisting, out gameStateId, out error);
			GameStateId = gameStateId;
			return result;
		}

		private static bool SaveSandbox(byte[] zipBytes, bool overwriteExisting, out string gameStateId, out string errorMessage)
		{
			bool flag = false;
			errorMessage = null;
			try
			{
				string text = null;
				string gameStatesBaseFolder = Game.Instance.GameStateManager.GameStatesBaseFolder;
				string text2 = $"{Guid.NewGuid().ToString()}.zip";
				string text3 = Utilities.CombinePaths(gameStatesBaseFolder, Guid.NewGuid().ToString());
				string text4 = Utilities.CombinePaths(text3, text2);
				Directory.CreateDirectory(text3);
				File.WriteAllBytes(text4, zipBytes);
				try
				{
					switch (lzip.decompress_File(text4, text3))
					{
					case 1:
					{
						text = File.ReadAllText(Utilities.CombinePaths(text3, "Name.txt"));
						text = Utilities.ScrubFileName(text);
						string text5 = Utilities.CombinePaths(gameStatesBaseFolder, text);
						string text6 = null;
						if (!Directory.Exists(text5))
						{
							Directory.CreateDirectory(text5);
						}
						else
						{
							if (!overwriteExisting)
							{
								throw new SandboxAlreadyExistsException();
							}
							text6 = Utilities.CombinePaths(gameStatesBaseFolder, Guid.NewGuid().ToString());
							Directory.Move(text5, text6);
						}
						string text7 = Utilities.CombinePaths(text5, "Active");
						try
						{
							DirectoryInfo directoryInfo = new DirectoryInfo(text7);
							directoryInfo.Create();
							directoryInfo.Delete();
							Directory.Move(text3, text7);
							File.Delete(Utilities.CombinePaths(text7, "Name.txt"));
							string text8 = Utilities.CombinePaths(text7, "LaunchLocations.xml");
							if (File.Exists(text8))
							{
								File.Move(text8, Utilities.CombinePaths(text7, "..", "LaunchLocations.xml"));
							}
							GameState gameState = Game.Instance.GameStateManager.LoadGameState(text);
							VerifyUserHasRequiredPurchases(gameState);
							if (gameState.Type != GameStateType.Default)
							{
								gameState.Type = GameStateType.Default;
								gameState.Save();
							}
							FlightStateData flightStateData = gameState.LoadFlightStateData();
							if (!string.IsNullOrEmpty(flightStateData.LegacySolarSystemId))
							{
								if (flightStateData.PlanetarySystem == null)
								{
									Guid empty = Guid.Empty;
									ModApi.CelestialData.CelestialDatabase celestialDatabase = Game.Instance.CelestialDatabase;
									FileInfo fileInfo = new FileInfo(Path.Combine(text7, "SolarSystem.xml"));
									if (!fileInfo.Exists)
									{
										Debug.LogError("Unknown error downloading sandbox. It appears to be referencing a legacy solar system that cannot be found.");
										empty = celestialDatabase.DefaultPlanetarySystemV1Id;
									}
									else
									{
										empty = celestialDatabase.InstallLegacySolarSystem(fileInfo.FullName);
										celestialDatabase.RefreshDatabase();
										fileInfo.Delete();
									}
									flightStateData.ChangePlanetarySystem(celestialDatabase.GetFile(empty), useFilePath: false);
								}
								flightStateData.Save();
							}
							FileInfo[] files = directoryInfo.Parent.GetFiles("*.*", SearchOption.AllDirectories);
							foreach (FileInfo fileInfo2 in files)
							{
								try
								{
									fileInfo2.CreationTime = DateTime.Now;
									fileInfo2.LastAccessTime = DateTime.Now;
									fileInfo2.LastWriteTime = DateTime.Now;
								}
								catch (Exception exception)
								{
									Debug.LogException(exception);
								}
							}
							text4 = Utilities.CombinePaths(text7, text2);
							if (text6 != null)
							{
								Utilities.DeleteDirectoryFromPersistentData(text6, recursive: true);
							}
							flag = true;
							Debug.LogFormat("Sandbox successfully extracted to: {0}", text7);
						}
						catch (RequiresPurchaseException)
						{
							if (Directory.Exists(text5))
							{
								Utilities.DeleteDirectoryFromPersistentData(text5, recursive: true);
							}
							if (text6 != null)
							{
								Directory.Move(text6, text5);
							}
							throw;
						}
						catch (Exception ex2)
						{
							Debug.LogException(ex2);
							if (text6 != null)
							{
								if (Directory.Exists(text5))
								{
									Utilities.DeleteDirectoryFromPersistentData(text5, recursive: true);
								}
								Directory.Move(text6, text5);
							}
							errorMessage = $"Error moving sandbox to final location: {ex2.Message}";
						}
						break;
					}
					case -1:
						errorMessage = "Could not initialize sandbox zip archive";
						break;
					case -2:
						errorMessage = "Sandbox zip archive failed extraction";
						break;
					}
				}
				finally
				{
					if (flag)
					{
						File.Delete(text4);
						Game.Instance.GameStateManager.ProcessDownloadedSandbox(text);
					}
					else if (Directory.Exists(text3))
					{
						Utilities.DeleteDirectoryFromPersistentData(text3, recursive: true);
					}
				}
				gameStateId = text;
			}
			catch (RequiresPurchaseException)
			{
				throw;
			}
			catch (SandboxAlreadyExistsException)
			{
				throw;
			}
			catch (Exception ex5)
			{
				errorMessage = $"Error saving downloaded sandbox: {ex5.Message}";
				gameStateId = null;
			}
			return flag;
		}

		private static void VerifyUserHasRequiredPurchases(GameState gameState)
		{
			IInAppPurchaseFeature sandboxBundle = Game.Instance.InAppPurchases.Features.SandboxBundle;
			if (gameState.Mode == GameStateMode.Sandbox)
			{
				if (!sandboxBundle.Unlocked)
				{
					throw new RequiresPurchaseException("Upgrade to the " + sandboxBundle.ProductName + " to unlock support for downloading community sandboxes.", sandboxBundle);
				}
			}
			else if (gameState.Mode == GameStateMode.Career)
			{
				IInAppPurchaseFeature careerBundle = Game.Instance.InAppPurchases.Features.CareerBundle;
				if (!careerBundle.Unlocked)
				{
					throw new RequiresPurchaseException("Upgrade to the " + careerBundle.ProductName + " to unlock support for downloading community career sandboxes.", careerBundle);
				}
				if (!gameState.Career.IsStock && !sandboxBundle.Unlocked)
				{
					throw new RequiresPurchaseException("Upgrade to the " + sandboxBundle.ProductName + " to unlock support for downloading custom career sandboxes.", sandboxBundle);
				}
			}
		}
	}
}
