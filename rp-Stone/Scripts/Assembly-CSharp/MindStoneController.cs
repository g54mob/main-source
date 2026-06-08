using System;
using System.Diagnostics;
using System.IO;
using Stonescript;
using Stonescript.Compiler;
using Stonescript.Runtime;
using UnityEngine;

public class MindStoneController : MonoBehaviour
{
	private string[] _program;

	private string[] defaultProgram = new string[7] { "?hp < 7", "  activate potion", "?loc = caves", "  equipL sword", "  equipR shield", "  ?foe = boss", "    equip crossbow" };

	private DateTime programModified;

	private bool hasMindStone;

	public Machine stonescript;

	private MindStoneGameModel gameModel;

	private Script mainScript;

	private Executable main;

	private bool hasCopiedStonescriptFolder;

	private StonescriptStorage storage;

	private int saveId = -1;

	private int frameTime = -1;

	private Stopwatch stopwatch = new Stopwatch();

	public string[] program
	{
		get
		{
			return _program;
		}
		set
		{
			bool flag = false;
			string[] array = _program;
			_program = value;
			if (_program == null || array == null)
			{
				if (_program != array)
				{
					programModified = DateTime.UtcNow;
				}
				return;
			}
			if (_program.Length != array.Length)
			{
				flag = true;
			}
			else
			{
				for (int i = 0; i < _program.Length; i++)
				{
					if (_program[i] != array[i])
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				programModified = DateTime.UtcNow;
			}
		}
	}

	public MindStoneGameModel GameModel => gameModel;

	public bool mindstoneEnabledMasterSwitch { get; set; }

	public static MindStoneController singleton { get; private set; }

	public void Activate()
	{
		hasMindStone = QuestController.singleton.IsAvailable("automate");
		if (!hasMindStone)
		{
			return;
		}
		if (!hasCopiedStonescriptFolder)
		{
			CopyStonescriptFolder();
			hasCopiedStonescriptFolder = true;
		}
		if (gameModel == null)
		{
			gameModel = new MindStoneGameModel();
			gameModel.SetInputProvider(GetComponent<MindstoneInputProvider>());
		}
		if (stonescript == null)
		{
			stonescript = new Machine();
			stonescript.CreateComponent("Mindstone");
			StonescriptGlobals.RegisterAll(stonescript, gameModel);
			stonescript.RegisterVariable("perf.frameTime", () => frameTime);
		}
		LoadStorage();
		if (mainScript == null)
		{
			mainScript = new Script();
			mainScript.name = "Mindstone.main";
			mainScript.Lines = program;
			mainScript.modifiedTimestamp = programModified;
		}
		else if (programModified != mainScript.modifiedTimestamp)
		{
			mainScript.Lines = program;
			mainScript.modifiedTimestamp = programModified;
		}
		if (main == null)
		{
			main = stonescript.Compile(mainScript);
		}
		stonescript.RecompileDirty();
		gameModel.Storage = storage;
		gameModel.PrepareToRun();
		gameModel.ClearResults();
	}

	public void ClearVariables()
	{
		if (stonescript != null)
		{
			stonescript.ClearVariables();
		}
		if (gameModel != null)
		{
			gameModel.ClearResults();
		}
		mindstoneEnabledMasterSwitch = true;
	}

	public bool CopyStonescriptFolder()
	{
		AStorage fileStorage = SaveFiles.singleton.storage;
		fileStorage.StreamingCopy("Stonescript", "Stonescript", delegate(FileInfo fileInfo, string dstPath)
		{
			bool flag = !fileStorage.Exists(dstPath) || ((fileInfo.LastWriteTime > fileStorage.GetModifiedTime(dstPath)) ? true : false);
			return fileInfo.Extension == ".txt" && flag;
		});
		if (fileStorage.Exists("Stonescript"))
		{
			return true;
		}
		throw new Exception("Unable to create Stonescript folder");
	}

	public void UpdateTic()
	{
		if (!hasMindStone || !base.enabled || !mindstoneEnabledMasterSwitch)
		{
			if (gameModel != null)
			{
				gameModel.SetStartEvent(start: false);
			}
			return;
		}
		gameModel.HandleSimulationTic();
		if (main != null)
		{
			stopwatch.Restart();
			main.Execute();
			stopwatch.Stop();
			frameTime = (int)stopwatch.ElapsedMilliseconds;
			if (DevicePerformanceGUI.singleton != null)
			{
				DevicePerformanceGUI.singleton.AddStonescriptMilliseconds(frameTime);
			}
		}
		gameModel.ExecuteResults(stonescript.Results);
		gameModel.SetStartEvent(start: false);
		gameModel.SetLoopEvent(loop: false);
	}

	public void ClearProgress()
	{
		base.enabled = false;
		stonescript = null;
		if (gameModel != null)
		{
			gameModel.ClearResults();
			gameModel.ClearCache();
			gameModel.ResetGameElements();
		}
		gameModel = null;
		storage = null;
		saveId = -1;
		string[] array = Utils.BreakIntoLines(Te.xt("tid_stonescript_instructions"), 45);
		program = new string[array.Length + defaultProgram.Length + 1];
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			if (text != "")
			{
				text = "// " + text;
			}
			program[num] = text;
			num++;
		}
		program[num] = "";
		num++;
		for (int j = 0; j < defaultProgram.Length; j++)
		{
			program[num] = defaultProgram[j];
			num++;
		}
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("enabled", base.enabled);
		SlimJson.AddProperty("program", program);
		if (saveId >= 0)
		{
			SlimJson.AddProperty("saveId", saveId);
		}
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		if (sjson != null)
		{
			base.enabled = SlimJson.ParseBool(sjson, "enabled");
			if (SlimJson.HasKey(sjson, "program"))
			{
				program = SlimJson.ParseArray(sjson, "program");
			}
			if (SlimJson.HasKey(sjson, "saveId"))
			{
				saveId = SlimJson.ParseInt(sjson, "saveId");
			}
		}
		else
		{
			base.enabled = false;
		}
	}

	public StonescriptStorage GetOrCreateStonescriptStorage()
	{
		if (storage == null)
		{
			if (saveId < 0)
			{
				saveId = StonescriptStorage.FindAvailableSaveId(SaveFiles.singleton.storage);
			}
			storage = new StonescriptStorage(SaveFiles.singleton.storage, saveId.ToString());
			if (gameModel != null)
			{
				gameModel.Storage = storage;
			}
		}
		return storage;
	}

	public void SaveStorage()
	{
		if (storage == null)
		{
			if (!base.enabled || !hasMindStone || stonescript == null)
			{
				return;
			}
			if (saveId < 0)
			{
				saveId = StonescriptStorage.FindAvailableSaveId(SaveFiles.singleton.storage);
				if (saveId < 0)
				{
					return;
				}
			}
			storage = new StonescriptStorage(SaveFiles.singleton.storage, saveId.ToString());
			if (gameModel != null)
			{
				gameModel.Storage = storage;
			}
		}
		storage.Save();
	}

	public void LoadStorage()
	{
		if (!base.enabled || !hasMindStone || stonescript == null || saveId < 0)
		{
			return;
		}
		if (storage == null)
		{
			storage = new StonescriptStorage(SaveFiles.singleton.storage, saveId.ToString());
			if (gameModel != null)
			{
				gameModel.Storage = storage;
			}
		}
		storage.Load();
		if (stonescript != null)
		{
			stonescript.Storage = SaveFiles.singleton.storage;
		}
	}

	private void Awake()
	{
		singleton = this;
		base.enabled = false;
	}
}
