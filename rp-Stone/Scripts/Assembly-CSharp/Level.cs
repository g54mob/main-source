using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class Level : MonoBehaviour
{
	public delegate bool CompletableCallback();

	public const int X_PER_SECTION = 69;

	public static Action<string, string> OnCustomEvent;

	public float secondsLeftToStopSpawningEnemies = 5f;

	public int moneyFloatingTextDelay = 9;

	public Background defaultBackground;

	public Pickup headStonePickupPrefab;

	private Data.Quest questData;

	private Background _background;

	private Background foreground;

	public bool EnableRendering = true;

	private List<Character> characters = new List<Character>();

	private List<Summon> summons = new List<Summon>();

	private List<Summon> deadSummons = new List<Summon>();

	private List<Enemy> enemies = new List<Enemy>();

	private List<Neutral> neutrals = new List<Neutral>();

	private List<Bullet> bullets = new List<Bullet>();

	private List<Bullet> enemyBullets = new List<Bullet>();

	private List<Pickup> pickups = new List<Pickup>();

	private List<Decoration> decorations = new List<Decoration>();

	private List<HarvestableResource> harvestableResources = new List<HarvestableResource>();

	private List<WayPoint> wayPoints = new List<WayPoint>();

	private List<IAsciiObject> asciiObjects = new List<IAsciiObject>();

	private int totalEncounterIncidence;

	private int spawnNextEncounterAtX;

	private float secondsLeft;

	private bool stopSpawningEnemies;

	private bool levelComplete;

	private int enemiesKilled;

	private GameCamera _gameCamera = new GameCamera();

	private int lastHeroPosX;

	private int lastSectionIndex;

	private int lastEnemyCount;

	private List<Data.Trigger> activeTriggers = new List<Data.Trigger>();

	private SafeInt _gameTime;

	private int _sectionIndex;

	private int endLevelDelay;

	public CompletableCallback completable;

	public int loops;

	private int instanceCounter;

	private List<Character> _workCharacters = new List<Character>();

	private List<Data.Trigger> _triggersToExecute = new List<Data.Trigger>();

	private bool _lockTriggerExecuteLoop;

	public Data.Quest QuestData
	{
		get
		{
			return questData;
		}
		set
		{
			questData = value;
		}
	}

	public Background background => _background;

	public List<Character> Characters => characters;

	public List<Summon> Summons => summons;

	public List<Summon> DeadSummons => deadSummons;

	public List<Enemy> Enemies => enemies;

	public List<Neutral> Neutrals => neutrals;

	public List<Bullet> Bullets => bullets;

	public List<Bullet> EnemyBullets => enemyBullets;

	public List<Pickup> Pickups => pickups;

	public List<Decoration> Decorations => decorations;

	public List<HarvestableResource> HarvestableResources => harvestableResources;

	public List<WayPoint> WayPoints => wayPoints;

	public List<IAsciiObject> AsciiObjects => asciiObjects;

	public bool LevelComplete
	{
		get
		{
			return levelComplete;
		}
		set
		{
			levelComplete = value;
		}
	}

	public int EnemiesKilled => enemiesKilled;

	public int MoneyEarned { get; set; }

	public int XpEarned { get; set; }

	public GameCamera gameCamera => _gameCamera;

	public int heroLimitX { get; set; }

	public int gameTime
	{
		get
		{
			return _gameTime.GetValue();
		}
		set
		{
			_gameTime = new SafeInt(value);
		}
	}

	public int sectionIndex => _sectionIndex;

	public int preventLevelComplete { get; set; }

	public static event Action<Level, int, List<Character>> OnNextSection;

	public static event Action<Level> OnReset;

	public string DiagnosticsString()
	{
		string text = "";
		text = text + "cmp" + (levelComplete ? "T" : "F");
		text = text + " sect" + _sectionIndex;
		text = text + " endDl" + endLevelDelay;
		text = text + " prvnt" + preventLevelComplete;
		text = text + " : chr" + characters.Count;
		text = text + " enm" + enemies.Count;
		text = text + " pkp" + pickups.Count;
		text = text + " dco" + decorations.Count;
		text = text + " way" + wayPoints.Count;
		text = text + " hrv" + HarvestablesAhead();
		if (questData != null && questData.sections == null)
		{
			text = text + " s" + secondsLeft.ToString("F2");
		}
		return text;
	}

	public void Reset(bool isSubquest)
	{
		GameStates.Singleton.hero.SetState(Hero.State.Idle);
		GameStates.Singleton.hero.StopAttacking();
		ClearBackground();
		ClearForeground();
		if (isSubquest)
		{
			for (int i = 0; i < summons.Count; i++)
			{
				characters.Remove(summons[i]);
			}
		}
		else
		{
			summons.Clear();
		}
		deadSummons.Clear();
		characters.Remove(GameStates.Singleton.hero);
		for (int j = 0; j < characters.Count; j++)
		{
			UnityEngine.Object.DestroyImmediate(characters[j].gameObject);
		}
		characters.Clear();
		characters.Add(GameStates.Singleton.hero);
		enemies.Clear();
		bullets.Clear();
		enemyBullets.Clear();
		pickups.Clear();
		decorations.Clear();
		harvestableResources.Clear();
		wayPoints.Clear();
		if (isSubquest)
		{
			for (int k = 0; k < summons.Count; k++)
			{
				characters.Add(summons[k]);
			}
		}
		for (int l = 0; l < asciiObjects.Count; l++)
		{
			MonoBehaviour monoBehaviour = asciiObjects[l] as MonoBehaviour;
			if (monoBehaviour != null)
			{
				UnityEngine.Object.Destroy(monoBehaviour.gameObject);
			}
		}
		asciiObjects.Clear();
		spawnNextEncounterAtX = 0;
		secondsLeft = 0f;
		stopSpawningEnemies = false;
		LevelComplete = false;
		enemiesKilled = 0;
		MoneyEarned = 0;
		heroLimitX = int.MaxValue;
		lastHeroPosX = -9999;
		activeTriggers.Clear();
		gameCamera.Reset();
		lastEnemyCount = 0;
		endLevelDelay = 0;
		preventLevelComplete = 0;
		completable = null;
		Precompute();
		LoadQuestBackgrounds();
		gameTime = 0;
		_sectionIndex = -2;
		lastSectionIndex = -2;
		if (questData.sections != null)
		{
			NextSection();
			NextSection();
			gameCamera.JumpToDestination();
		}
		Level.OnReset?.Invoke(this);
		DiagnosticsDamageTaken.singleton.PrintAndReset();
	}

	private void Update()
	{
		if (!levelComplete)
		{
			SortCharacters1Pass();
		}
	}

	public void UpdateTic()
	{
		if (levelComplete)
		{
			return;
		}
		gameTime++;
		AbilityClock.UpdateTic();
		for (int i = 0; i < bullets.Count; i++)
		{
			bullets[i].UpdateTic();
		}
		for (int j = 0; j < enemyBullets.Count; j++)
		{
			enemyBullets[j].UpdateTic();
		}
		for (int k = 0; k < summons.Count; k++)
		{
			summons[k].UpdateTic();
		}
		for (int l = 0; l < deadSummons.Count; l++)
		{
			deadSummons[l].UpdateTic();
		}
		SortEnemies1Pass();
		for (int m = 0; m < enemies.Count; m++)
		{
			enemies[m].UpdateTic();
		}
		for (int n = 0; n < neutrals.Count; n++)
		{
			neutrals[n].UpdateTic();
		}
		for (int num = 0; num < pickups.Count; num++)
		{
			pickups[num].UpdateTic();
		}
		for (int num2 = 0; num2 < decorations.Count; num2++)
		{
			decorations[num2].UpdateTic();
		}
		for (int num3 = 0; num3 < wayPoints.Count; num3++)
		{
			wayPoints[num3].UpdateTic();
		}
		for (int num4 = 0; num4 < asciiObjects.Count; num4++)
		{
			asciiObjects[num4].UpdateTic();
		}
		if (questData.sections != null)
		{
			if (preventLevelComplete <= 0 && _sectionIndex + 1 >= questData.sections.Length && Enemies.Count == 0 && Pickups.Count == 0 && WayPoints.Count == 0 && HarvestablesAhead() == 0 && (completable == null || completable()))
			{
				if (!questData.customCompletionLogic && endLevelDelay++ >= 30)
				{
					LevelComplete = true;
				}
			}
			else if (GameStates.Singleton.hero.PositionX >= 69 * _sectionIndex + 20)
			{
				NextSection();
			}
			else
			{
				endLevelDelay = 0;
			}
		}
		else
		{
			if (!stopSpawningEnemies && GameStates.Singleton.hero.PositionX >= spawnNextEncounterAtX && !IsInEmptyArea(GameStates.Singleton.hero.PositionX + GameStates.Singleton.asciiRenderer.width))
			{
				SpawnRandomEncounter();
				spawnNextEncounterAtX = GameStates.Singleton.hero.PositionX + UnityEngine.Random.Range(questData.minWalkToSpawn, questData.maxWalkToSpawn);
			}
			secondsLeft -= 0.03333333f;
			secondsLeft = Mathf.Max(0f, secondsLeft);
			if (secondsLeft < secondsLeftToStopSpawningEnemies)
			{
				stopSpawningEnemies = true;
			}
			if (secondsLeft <= 0.01f)
			{
				secondsLeft = 0f;
				if (!questData.customCompletionLogic && Enemies.Count <= 0 && Pickups.Count <= 0 && WayPoints.Count <= 0)
				{
					if (endLevelDelay++ >= 30)
					{
						LevelComplete = true;
					}
				}
				else
				{
					endLevelDelay = 0;
				}
			}
		}
		UpdateTriggers();
	}

	public Character GetCharacterWithId(string id)
	{
		for (int i = 0; i < characters.Count; i++)
		{
			if (characters[i].id == id)
			{
				return characters[i];
			}
		}
		Utils.LogWarning("Couldn't find character with id " + id);
		return null;
	}

	public Decoration GetDecorationWithId(string id)
	{
		for (int i = 0; i < decorations.Count; i++)
		{
			if (decorations[i].id == id)
			{
				return decorations[i];
			}
		}
		Utils.LogWarning("Couldn't find decoration with id " + id);
		return null;
	}

	private int HarvestablesAhead()
	{
		int num = 0;
		for (int i = 0; i < HarvestableResources.Count; i++)
		{
			HarvestableResource harvestableResource = HarvestableResources[i];
			if (harvestableResource.character.PositionX >= GameStates.Singleton.hero.PositionX && (harvestableResource.character.requiredForLevelCompletion || Inventory.Singleton.IsToolToHarvestEquipped(harvestableResource.resourceType)))
			{
				num++;
			}
		}
		return num;
	}

	private bool IsInEmptyArea(int x)
	{
		if (questData.emptyAreas != null)
		{
			for (int i = 0; i < questData.emptyAreas.Length; i++)
			{
				Data.Range range = questData.emptyAreas[i];
				if (x >= range.begin && x <= range.end)
				{
					string requiresFlag = range.requiresFlag;
					if (requiresFlag == null || requiresFlag == "" || ProgressFlags.GetFlag(requiresFlag))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public void LateUpdateTic()
	{
		_gameCamera.UpdateTic();
	}

	public void Draw(AsciiRenderProcedural r)
	{
		if (EnableRendering)
		{
			int screenOffsetX = 0;
			int num = 0;
			int num2 = -gameCamera.PositionX + (r.width >> 1);
			int num3 = -gameCamera.PositionZ + gameCamera.PositionY + (r.height >> 1);
			_background.Draw(r, screenOffsetX, num + num3, -num2, 0);
			DrawCharacters(r, num2, num3);
			DrawAdditionalObjects(r, num2, num3);
			if (foreground != null)
			{
				foreground.Draw(r, screenOffsetX, num + num3, -num2, 0);
			}
			r.ResetClip();
		}
	}

	private void DrawCharacters(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < characters.Count; i++)
		{
			characters[i].Draw(r, offsetX, offsetY);
			characters[i].FireOnPostDraw(r, offsetX, offsetY);
		}
	}

	private void DrawAdditionalObjects(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		for (int i = 0; i < asciiObjects.Count; i++)
		{
			asciiObjects[i].Draw(r, offsetX, offsetY);
		}
	}

	private void SortCharacters1Pass()
	{
		if (characters.Count <= 0)
		{
			return;
		}
		Character character = characters[0];
		for (int i = 1; i < characters.Count; i++)
		{
			Character character2 = characters[i];
			int num = character2.PositionZ + character2.sortTiebreaker / 100;
			int num2 = character.PositionZ + character.sortTiebreaker / 100;
			if (num < num2 || (num == num2 && ((character2.sortTiebreaker == character.sortTiebreaker && character2.PositionX > character.PositionX) || character2.sortTiebreaker < character.sortTiebreaker)))
			{
				characters[i] = character;
				characters[i - 1] = character2;
				character2 = character;
			}
			character = character2;
		}
	}

	private void SortEnemies1Pass()
	{
		if (enemies.Count <= 0)
		{
			return;
		}
		Enemy enemy = enemies[0];
		for (int i = 1; i < enemies.Count; i++)
		{
			Enemy enemy2 = enemies[i];
			if (enemy2.PositionX < enemy.PositionX)
			{
				enemies[i] = enemy;
				enemies[i - 1] = enemy2;
				enemy2 = enemy;
			}
			enemy = enemy2;
		}
	}

	public void AddCharacter(Character character)
	{
		character.Init();
		characters.Add(character);
		character.transform.parent = base.transform;
		SortCharacters1Pass();
		if (character.tags.Contains("prevent_level_complete"))
		{
			preventLevelComplete++;
		}
		if (character is Enemy)
		{
			enemies.Add(character as Enemy);
		}
		else if (character is Neutral)
		{
			neutrals.Add(character as Neutral);
		}
		else if (character is Bullet)
		{
			Bullet bullet = character as Bullet;
			if (bullet.tags.Contains("enemy"))
			{
				enemyBullets.Add(bullet);
			}
			else
			{
				bullets.Add(bullet);
			}
		}
		else if (character is Pickup)
		{
			pickups.Add(character as Pickup);
		}
		else if (character is Decoration)
		{
			decorations.Add(character as Decoration);
		}
		else if (character is WayPoint)
		{
			wayPoints.Add(character as WayPoint);
		}
		else if (character is Summon)
		{
			summons.Add(character as Summon);
		}
		HarvestableResource component = character.GetComponent<HarvestableResource>();
		if (component != null)
		{
			harvestableResources.Add(component);
		}
		GameCameraBinding component2 = character.GetComponent<GameCameraBinding>();
		if (component2 != null)
		{
			component2.gameCamera = gameCamera;
		}
		character.FireOnAddedToLevel();
	}

	public void RemoveCharacter(Character character)
	{
		characters.Remove(character);
		if (character.tags.Contains("prevent_level_complete"))
		{
			preventLevelComplete--;
		}
		if (character is Enemy)
		{
			enemies.Remove(character as Enemy);
		}
		else if (character is Neutral)
		{
			neutrals.Remove(character as Neutral);
		}
		else if (character is Bullet)
		{
			Bullet item = character as Bullet;
			bullets.Remove(item);
			enemyBullets.Remove(item);
		}
		else if (character is Pickup)
		{
			pickups.Remove(character as Pickup);
		}
		else if (character is Decoration)
		{
			decorations.Remove(character as Decoration);
		}
		else if (character is WayPoint)
		{
			wayPoints.Remove(character as WayPoint);
		}
		else if (character is Summon)
		{
			Summon item2 = character as Summon;
			summons.Remove(item2);
			deadSummons.Remove(item2);
		}
		if (character != null && character.gameObject != null)
		{
			HarvestableResource component = character.GetComponent<HarvestableResource>();
			if (component != null)
			{
				harvestableResources.Remove(component);
			}
		}
	}

	public void AddObject(IAsciiObject obj)
	{
		asciiObjects.Add(obj);
	}

	public void RemoveObject(IAsciiObject obj)
	{
		asciiObjects.Remove(obj);
	}

	public int SecondsLeft()
	{
		return (int)secondsLeft;
	}

	public void Complete()
	{
		CompleteQuestTriggers();
	}

	public void Leave()
	{
		LeaveQuestTriggers();
	}

	private void NextSection()
	{
		_sectionIndex++;
		int destinationX = _sectionIndex * 69;
		int num = (_sectionIndex + 1) * 69 - 24;
		if (_sectionIndex + 1 < questData.sections.Length)
		{
			Data.QuestSection questSection = questData.sections[_sectionIndex + 1];
			int num2 = ((questSection.minY > 0) ? questSection.minY : questData.walkLimitTop);
			int num3 = ((questSection.maxY > 0) ? questSection.maxY : questData.walkLimitBot);
			if (questSection.rndIds != null && questSection.rndIds.Length != 0)
			{
				for (int i = 0; i < questSection.rndCount; i++)
				{
					int num4 = UnityEngine.Random.Range(0, questSection.rndIds.Length);
					string encounterId = questSection.rndIds[num4];
					Data.Encounter encounter = questData.GetEncounter(encounterId);
					int overrideX = UnityEngine.Random.Range(questSection.minX, questSection.maxX) + num;
					int overrideZ = UnityEngine.Random.Range(num2, num3);
					Character item = SpawnEncounter(encounter, overrideX, overrideZ);
					_workCharacters.Add(item);
					UnityEngine.Random.Range(questSection.minLevel, questSection.maxLevel);
				}
			}
			if (questSection.procGen != null)
			{
				List<Data.Encounter> list = new List<Data.Encounter>();
				for (int j = 0; j < questData.encounters.Length; j++)
				{
					Data.Encounter encounter2 = questData.encounters[j];
					if (encounter2.points > 0 && (questSection.procGen.excludeIds == null || Array.IndexOf(questSection.procGen.excludeIds, encounter2.id) == -1))
					{
						list.Add(encounter2);
					}
				}
				int num5 = questSection.procGen.points;
				int num6 = num5 * -3 / 20;
				int num7 = 0;
				int num8 = RndStartingLevel(questSection.procGen.maxLevel);
				while (num5 > 0 && num7 < 5)
				{
					int index = UnityEngine.Random.Range(0, list.Count);
					Data.Encounter encounter3 = list[index];
					int num9 = encounter3.points + num8 - 1;
					int num10 = num5 - num9;
					if (num10 >= num6)
					{
						num5 = num10;
						num7 = 0;
						int overrideX2 = UnityEngine.Random.Range(questSection.minX, questSection.maxX) + num;
						int overrideZ2 = UnityEngine.Random.Range(num2, num3);
						Character character = SpawnEncounter(encounter3, overrideX2, overrideZ2);
						_workCharacters.Add(character);
						if (num8 > 5)
						{
							SetCharacterLevel(character, num8 - 5);
						}
						num8 = RndStartingLevel(questSection.procGen.maxLevel);
					}
					else
					{
						num7++;
						num8--;
					}
				}
			}
			if (_workCharacters.Count > 0)
			{
				SpreadOutEnemies(_workCharacters, questSection.minX + num, questSection.maxX + num, num2, num3);
			}
			if (questSection.fixedEncounters != null)
			{
				for (int k = 0; k < questSection.fixedEncounters.Length; k++)
				{
					Data.Encounter encounter4 = questSection.fixedEncounters[k];
					if (!encounter4.EvaluateConditions() || !EvaluateRandom(encounter4.random))
					{
						continue;
					}
					Data.Encounter encounter5 = encounter4;
					string instanceId = encounter5.instanceId;
					instanceCounter++;
					if (string.IsNullOrEmpty(instanceId))
					{
						_ = $"Unit{instanceCounter}";
					}
					if (encounter4.id != null && encounter4.prefab == null)
					{
						encounter5 = questData.GetEncounter(encounter4.id);
					}
					if (encounter5 != null)
					{
						if (!encounter5.EvaluateConditions() || !EvaluateRandom(encounter5.random))
						{
							continue;
						}
						int overrideX3 = questSection.fixedEncounters[k].x + num;
						int y = questSection.fixedEncounters[k].y;
						Character character2 = SpawnEncounter(encounter5, overrideX3, y);
						if (character2 != null)
						{
							if (encounter4.args != null && encounter5 != encounter4)
							{
								character2.ParseArguments(encounter4.args);
							}
							if (encounter4.level > 5)
							{
								SetCharacterLevel(character2, encounter4.level - 5);
							}
							if (character2.instanceId == null)
							{
								character2.instanceId = encounter4.instanceId;
							}
							_workCharacters.Add(character2);
						}
					}
					else
					{
						Utils.LogError("Could not find encounter with id " + encounter4.id);
					}
				}
			}
		}
		Level.OnNextSection?.Invoke(this, _sectionIndex, _workCharacters);
		_workCharacters.Clear();
		gameCamera.SetupLerpToPos(destinationX, gameCamera.PositionY, gameCamera.PositionZ, 0.11f);
	}

	private int RndStartingLevel(int maxLevel)
	{
		return Mathf.CeilToInt(Mathf.Pow(UnityEngine.Random.Range(0f, 1f), 0.3f) * (float)maxLevel);
	}

	private void SetCharacterLevel(Character c, int newLevel)
	{
		c.SetLevel(newLevel);
	}

	private bool EvaluateRandom(float randomChance)
	{
		if (!(randomChance >= 1f))
		{
			return randomChance >= UnityEngine.Random.Range(0f, 1f);
		}
		return true;
	}

	private void SpawnRandomEncounter()
	{
		if (questData.encounters == null || questData.encounters.Length == 0)
		{
			return;
		}
		Data.Encounter encounter = null;
		int num = UnityEngine.Random.Range(0, totalEncounterIncidence);
		for (int i = 0; i < questData.encounters.Length; i++)
		{
			if (num < questData.encounters[i].incidence)
			{
				encounter = questData.encounters[i];
				break;
			}
			num -= questData.encounters[i].incidence;
		}
		if (encounter == null)
		{
			Utils.LogError("Could not randomly select encounter. Revise logic.");
		}
		else
		{
			SpawnEncounter(encounter);
		}
	}

	private Character SpawnEncounter(Data.Encounter encounter, int overrideX = -9999, int overrideZ = -9999)
	{
		Character character = null;
		string prefab = encounter.prefab;
		if (!string.IsNullOrEmpty(prefab))
		{
			GameObject gameObject = Utils.InstantiatePrefab(prefab);
			if (gameObject != null)
			{
				character = gameObject.GetComponent<Character>();
				if (character != null)
				{
					if (encounter.args != null)
					{
						character.ParseArguments(encounter.args);
					}
					PositionCharacterForEncounter(character, encounter);
					if (overrideX > -9999)
					{
						character.PositionX = overrideX;
					}
					if (overrideZ > -9999)
					{
						character.PositionZ = overrideZ;
					}
					character.instanceId = encounter.instanceId;
					AddCharacter(character);
				}
				else
				{
					Utils.LogError("Instantiated encounter at path " + prefab + " however it is not a Character.");
				}
			}
		}
		if (character == null)
		{
			Utils.LogError("Couldn't instantiate encounter at prefab path " + prefab);
		}
		return character;
	}

	private void PositionCharacterForEncounter(Character character, Data.Encounter encounter)
	{
		if (encounter.x != int.MinValue)
		{
			character.PositionX = encounter.x;
		}
		else
		{
			character.PositionX = GameStates.Singleton.hero.PositionX + GameStates.Singleton.asciiRenderer.width;
		}
		if (encounter.y != int.MinValue)
		{
			character.PositionZ = encounter.y;
		}
		else
		{
			character.PositionZ = UnityEngine.Random.Range(questData.walkLimitTop, questData.walkLimitBot);
		}
	}

	private void SpreadOutEnemies(List<Character> characters, int minX, int maxX, int minZ, int maxZ)
	{
		if (characters.Count <= 1)
		{
			return;
		}
		Character character = null;
		characters.Sort((Character cA, Character cB) => cA.PositionX.CompareTo(cB.PositionX));
		int num = 10;
		while (--num >= 0)
		{
			Character character2 = characters[0];
			int num2 = character2.PositionX - minX;
			for (int num3 = 0; num3 < characters.Count; num3++)
			{
				int num4;
				if (num3 == characters.Count - 1)
				{
					num4 = maxX - character2.PositionX;
				}
				else
				{
					character = characters[num3 + 1];
					num4 = character.PositionX - character2.PositionX;
				}
				if (num3 == 0 && num2 > 0 && UnityEngine.Random.Range(0f, 1f) < 0.5f)
				{
					character2.PositionX--;
				}
				else if (num3 == characters.Count - 1 && num4 > 0 && UnityEngine.Random.Range(0f, 1f) < 0.5f)
				{
					character2.PositionX++;
				}
				else if (num2 > num4 && (num2 > 0 || num3 > 0))
				{
					character2.PositionX--;
				}
				else if (num2 < num4 && (num4 > 0 || num3 < characters.Count - 1))
				{
					character2.PositionX++;
				}
				num2 = character.PositionX - character2.PositionX;
				character2 = character;
			}
		}
		characters.Sort((Character cA, Character cB) => cA.PositionZ.CompareTo(cB.PositionZ));
		num = 10;
		while (--num >= 0)
		{
			Character character2 = characters[0];
			int num5 = character2.PositionZ - minZ;
			for (int num6 = 0; num6 < characters.Count; num6++)
			{
				int num7;
				if (num6 == characters.Count - 1)
				{
					num7 = maxZ - character2.PositionZ;
				}
				else
				{
					character = characters[num6 + 1];
					num7 = character.PositionZ - character2.PositionZ;
				}
				if (num6 == 0 && num5 > 0 && UnityEngine.Random.Range(0f, 1f) < 0.5f)
				{
					character2.PositionZ--;
				}
				else if (num6 == characters.Count - 1 && num7 > 0 && UnityEngine.Random.Range(0f, 1f) < 0.5f)
				{
					character2.PositionZ++;
				}
				else if (num5 > num7 && (num5 > 0 || num6 > 0))
				{
					character2.PositionZ--;
				}
				else if (num5 < num7 && (num7 > 0 || num6 < characters.Count - 1))
				{
					character2.PositionZ++;
				}
				num5 = character.PositionZ - character2.PositionZ;
				character2 = character;
			}
		}
	}

	private void UpdateTriggers()
	{
		if (activeTriggers.Count <= 0)
		{
			return;
		}
		bool flag = false;
		if (lastHeroPosX < GameStates.Singleton.hero.PositionX)
		{
			lastHeroPosX = GameStates.Singleton.hero.PositionX;
			flag = true;
		}
		bool flag2 = false;
		if (lastSectionIndex != _sectionIndex && questData.sections != null)
		{
			lastSectionIndex = _sectionIndex;
			flag2 = true;
		}
		bool flag3 = false;
		if (lastEnemyCount != enemies.Count)
		{
			lastEnemyCount = enemies.Count;
			flag3 = true;
		}
		if (flag || flag2 || flag3)
		{
			for (int i = 0; i < activeTriggers.Count; i++)
			{
				Data.Trigger trigger = activeTriggers[i];
				Data.TriggerCondition condition = trigger.condition;
				if ((condition.x < int.MaxValue || condition.section < int.MaxValue || condition.enemyCount >= 0) && (condition.x == int.MaxValue || lastHeroPosX >= condition.x) && (condition.section == int.MaxValue || _sectionIndex >= condition.section) && (condition.enemyCount < 0 || enemies.Count == condition.enemyCount))
				{
					_triggersToExecute.Add(trigger);
				}
			}
		}
		ExecuteSelectedTriggers();
	}

	private void CompleteQuestTriggers()
	{
		if (activeTriggers.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < activeTriggers.Count; i++)
		{
			if (activeTriggers[i].condition.completeQuest)
			{
				_triggersToExecute.Add(activeTriggers[i]);
			}
		}
		ExecuteSelectedTriggers();
	}

	private void LeaveQuestTriggers()
	{
		if (activeTriggers.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < activeTriggers.Count; i++)
		{
			if (activeTriggers[i].condition.leaveQuest)
			{
				_triggersToExecute.Add(activeTriggers[i]);
			}
		}
		ExecuteSelectedTriggers();
	}

	private void ExecuteSelectedTriggers()
	{
		if (_triggersToExecute.Count > 0 && !_lockTriggerExecuteLoop)
		{
			_lockTriggerExecuteLoop = true;
			for (int i = 0; i < _triggersToExecute.Count; i++)
			{
				ExecuteTrigger(_triggersToExecute[i]);
			}
			_triggersToExecute.Clear();
			_lockTriggerExecuteLoop = false;
		}
	}

	private void ExecuteTrigger(Data.Trigger trigger)
	{
		Utils.LogIfEditor("Executing trigger: " + trigger.ToString());
		activeTriggers.Remove(trigger);
		if (trigger.type == Data.Trigger.Type.CompleteQuest)
		{
			GameStates.Singleton.CompleteQuest();
		}
		else if (trigger.type == Data.Trigger.Type.StartQuest || trigger.type == Data.Trigger.Type.SubQuest)
		{
			if (trigger.instructions == null || trigger.instructions.Length < 1)
			{
				Utils.LogError("Cannot trigger quest start because no quest id was provided.");
				return;
			}
			string text = trigger.instructions[0];
			Data.Quest quest = null;
			if (trigger.instructions.Length >= 2 && trigger.instructions[1] == "procGenLevel")
			{
				int level = questData.level;
				quest = QuestController.singleton.GetQuestByIdAndDifficulty(text, level);
			}
			else
			{
				quest = QuestController.singleton.GetQuestById(text);
			}
			if (quest == null)
			{
				Utils.LogError("Couldn't trigger start of quest " + text + " because it was not found... or something like that.");
			}
			else if (trigger.type == Data.Trigger.Type.StartQuest)
			{
				GameStates.Singleton.StartQuest(quest);
			}
			else
			{
				GameStates.Singleton.SubQuest(quest);
			}
		}
		else if (trigger.type == Data.Trigger.Type.SetFlags)
		{
			int num = 0;
			while (trigger.instructions != null && num < trigger.instructions.Length)
			{
				ProgressFlags.SetFlag(trigger.instructions[num]);
				num++;
			}
		}
		else if (trigger.type == Data.Trigger.Type.UnsetFlags)
		{
			int num2 = 0;
			while (trigger.instructions != null && num2 < trigger.instructions.Length)
			{
				ProgressFlags.SetFlag(trigger.instructions[num2], value: false);
				num2++;
			}
		}
		else if (trigger.type == Data.Trigger.Type.DisablePause)
		{
			GameStates.Singleton.userCanLeaveQuest = false;
		}
		else if (trigger.type == Data.Trigger.Type.EnablePause)
		{
			GameStates.Singleton.userCanLeaveQuest = true;
		}
		else if (trigger.type == Data.Trigger.Type.PlayMusic)
		{
			if (trigger.instructions.Length >= 2)
			{
				MusicController.singleton.Play(trigger.instructions[0], Utils.ParseFloat(trigger.instructions[1]));
			}
			else
			{
				MusicController.singleton.Play(trigger.instructions[0]);
			}
		}
		else if (trigger.type == Data.Trigger.Type.FadeOutMusic)
		{
			if (trigger.instructions != null && trigger.instructions.Length != 0)
			{
				MusicController.singleton.FadeToSilence(Utils.ParseFloat(trigger.instructions[0]));
			}
			else
			{
				MusicController.singleton.FadeToSilence();
			}
		}
		else if (trigger.type == Data.Trigger.Type.PlayAmbient)
		{
			AmbianceController.singleton.AddAmbient(trigger.instructions[0]);
		}
		else if (trigger.type == Data.Trigger.Type.StopAmbient)
		{
			AmbianceController.singleton.StopAllAmbient();
		}
		else if (trigger.type == Data.Trigger.Type.PauseAI)
		{
			GameStates.Singleton.hero.PauseAI(Utils.ParseFloat(trigger.instructions[0]));
		}
		else if (trigger.type == Data.Trigger.Type.HideHUD)
		{
			QuestData.hideHUD = true;
		}
		else if (trigger.type == Data.Trigger.Type.ShowHUD)
		{
			QuestData.hideHUD = false;
		}
		else if (trigger.type == Data.Trigger.Type.CustomEvent && OnCustomEvent != null)
		{
			OnCustomEvent(trigger.instructions[0], trigger.instructions[1]);
		}
	}

	private void Precompute()
	{
		totalEncounterIncidence = 0;
		if (questData.encounters != null)
		{
			for (int i = 0; i < questData.encounters.Length; i++)
			{
				totalEncounterIncidence += questData.encounters[i].incidence;
			}
		}
		if (questData.fixedEncounters != null)
		{
			for (int j = 0; j < questData.fixedEncounters.Length; j++)
			{
				Data.Encounter encounter = questData.fixedEncounters[j];
				if (encounter.EvaluateConditions() && EvaluateRandom(encounter.random))
				{
					Character character = SpawnEncounter(encounter);
					if (character != null && questData.level > 5 && encounter.level > 5)
					{
						SetCharacterLevel(character, questData.level - 5);
					}
				}
			}
		}
		secondsLeft = questData.seconds;
		GameStates.Singleton.hero.PositionX = questData.initialHeroX;
		GameStates.Singleton.hero.PositionY = 0;
		GameStates.Singleton.hero.PositionZ = ((questData.initialHeroZ != 0) ? questData.initialHeroZ : ((questData.walkLimitTop + questData.walkLimitBot) / 2));
		GameStates.Singleton.hero.faerie.StartQuest();
		gameCamera.PrepareForQuest(questData);
		if (questData.triggers != null)
		{
			for (int k = 0; k < questData.triggers.Length; k++)
			{
				Data.Trigger trigger = questData.triggers[k];
				string requiresFlag = trigger.condition.requiresFlag;
				string blockedByFlag = trigger.condition.blockedByFlag;
				if ((requiresFlag == null || requiresFlag == "" || ProgressFlags.GetFlag(requiresFlag)) && (blockedByFlag == null || blockedByFlag == "" || !ProgressFlags.GetFlag(blockedByFlag)))
				{
					activeTriggers.Add(trigger);
				}
			}
		}
		AddHeadStones();
	}

	private void LoadQuestBackgrounds()
	{
		LoadBackground(questData.background);
		LoadForeground(questData.foreground);
	}

	public void LoadBackground(string path)
	{
		ClearBackground();
		GameObject gameObject = null;
		if (!string.IsNullOrEmpty(path))
		{
			gameObject = Utils.InstantiatePrefab("Quests/" + path);
		}
		if (gameObject != null)
		{
			_background = gameObject.GetComponent<Background>();
			_background.transform.parent = base.transform;
		}
		else
		{
			_background = defaultBackground;
		}
	}

	public void LoadForeground(string path)
	{
		ClearForeground();
		if (!string.IsNullOrEmpty(path))
		{
			GameObject gameObject = Utils.InstantiatePrefab("Quests/" + path);
			if (gameObject != null)
			{
				foreground = gameObject.GetComponent<Background>();
				foreground.transform.parent = base.transform;
			}
		}
	}

	private void ClearBackground()
	{
		if (_background != null)
		{
			if (_background != defaultBackground)
			{
				UnityEngine.Object.Destroy(_background.gameObject);
			}
			_background = null;
		}
	}

	private void ClearForeground()
	{
		if (foreground != null)
		{
			UnityEngine.Object.Destroy(foreground.gameObject);
			foreground = null;
		}
	}

	private void AddHeadStones()
	{
		List<IntPosition> stonesForQuest = HeadStones.GetStonesForQuest(questData.id, questData.level);
		for (int i = 0; i < stonesForQuest.Count; i++)
		{
			IntPosition intPosition = stonesForQuest[i];
			Pickup pickup = UnityEngine.Object.Instantiate(headStonePickupPrefab);
			pickup.PositionX = intPosition.x;
			pickup.PositionZ = intPosition.z;
			AddCharacter(pickup);
		}
	}

	public void SetTime(int time)
	{
		gameTime = time;
	}

	private void TestRNGLevelCurve()
	{
		Debug.Log("### TESTING RNG STARTING LEVEL CURVE ###");
		int num = 5000;
		int[] array = new int[10];
		for (int i = 0; i < num; i++)
		{
			int num2 = RndStartingLevel(10) - 1;
			array[num2]++;
		}
		for (int j = 0; j < array.Length; j++)
		{
			Debug.Log("[" + (j + 1) + "] = " + array[j] + ", " + ((float)array[j] / (float)num * 100f).ToString("F2") + "%");
		}
	}

	private void Awake()
	{
		Character.OnCharacterDied += HandleOnCharacterDied;
		Enemy.OnEnemyEngaged += HandleOnEnemyEngaged;
	}

	private void OnDestroy()
	{
		Character.OnCharacterDied -= HandleOnCharacterDied;
		Enemy.OnEnemyEngaged -= HandleOnEnemyEngaged;
	}

	public void EarnMoney(int amount, Character characterToShowFloatingText = null)
	{
		MoneyEarned += amount;
		InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, amount);
		if (characterToShowFloatingText != null)
		{
			FloatingText floatingText = characterToShowFloatingText.ShowFloatingText('@'.ToString() + amount, moneyFloatingTextDelay);
			if (floatingText != null)
			{
				floatingText.Message.color = ColorConstants.white;
			}
		}
	}

	private void HandleOnCharacterDied(Character character, Character.DeathReason reason, Damage damage)
	{
		if (character as Enemy != null)
		{
			enemiesKilled++;
			if (character.Money > 0)
			{
				if (!XPController.singleton.isMaxLevel)
				{
					XpEarned += character.Money;
				}
				if (character.moneyType == Data.Resource.Xi && ProgressFlags.GetFlag("show_xi"))
				{
					EarnMoney(character.Money, character);
				}
				else if (character.moneyType != Data.Resource.Xi)
				{
					InventoryResources.singleton.AddResourceOfType(character.moneyType, character.Money);
					string message = character.Money + " " + MoneyUI.GetResourceName(character.moneyType, character.Money != 1);
					character.ShowFloatingText(message);
				}
			}
		}
		for (int i = 0; i < activeTriggers.Count; i++)
		{
			string characterDead = activeTriggers[i].condition.characterDead;
			if (!string.IsNullOrEmpty(characterDead) && characterDead == character.id)
			{
				_triggersToExecute.Add(activeTriggers[i]);
			}
		}
		ExecuteSelectedTriggers();
	}

	private void HandleOnEnemyEngaged(Enemy enemy)
	{
		for (int i = 0; i < activeTriggers.Count; i++)
		{
			string enemyEngaged = activeTriggers[i].condition.enemyEngaged;
			if (!string.IsNullOrEmpty(enemyEngaged) && enemyEngaged == enemy.id)
			{
				_triggersToExecute.Add(activeTriggers[i]);
			}
		}
		ExecuteSelectedTriggers();
	}

	public int GetEnemyLimitX(Character character)
	{
		return gameCamera.PositionX + (GameStates.Singleton.asciiRenderer.width >> 1) - character.CollisionWidth - 2;
	}
}
