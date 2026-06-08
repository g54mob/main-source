using System.Collections.Generic;

public abstract class AStonescriptGameModel
{
	public abstract void HandleSimulationTic();

	public abstract void Print(string str);

	public abstract void Print(string str, Character character);

	public abstract void Error(string str);

	public abstract void Warn(string str);

	public abstract int GetApplicationState();

	public abstract object GetStateNumber(List<object> parameters, InvocationContext ctx);

	public abstract string GetCurrentLocation();

	public abstract string GetCurrentLocationID();

	public abstract string GetCurrentLocationName();

	public abstract int GetCurrentLocationStars();

	public abstract int GetCurrentLocationBestTime();

	public abstract int GetCurrentLocationAverageTime();

	public abstract bool IsCurrentLocationCustomQuest();

	public abstract int GetTime();

	public abstract int GetTotalTime();

	public abstract string GetFoe();

	public abstract string GetFoeId();

	public abstract string GetFoeName();

	public abstract int GetFoeDamage();

	public abstract int GetFoeDistance();

	public abstract int GetFoeCount();

	public abstract object GetFoeCount(List<object> parameters, InvocationContext ctx);

	public abstract int GetFoeHitpoints();

	public abstract int GetFoeMaxHitpoints();

	public abstract int GetFoeArmor();

	public abstract int GetFoeMaxArmor();

	public abstract string GetPickup();

	public abstract int GetPickupDistance();

	public abstract string GetHarvest();

	public abstract int GetHarvestDistance();

	public abstract int GetHitpoints();

	public abstract int GetMaxHitpoints();

	public abstract int GetArmor();

	public abstract int GetArmorFraction();

	public abstract int GetMaxArmor();

	public abstract int GetPosX();

	public abstract int GetPosY();

	public abstract int GetPosZ();

	public abstract int GetPlayerBuffCount();

	public abstract string GetPlayerBuffString();

	public abstract string GetPlayerOldestBuff();

	public abstract int GetPlayerDebuffCount();

	public abstract string GetPlayerDebuffString();

	public abstract string GetPlayerOldestDebuff();

	public abstract int GetFoeBuffCount();

	public abstract string GetFoeBuffString();

	public abstract int GetFoeDebuffCount();

	public abstract string GetFoeDebuffString();

	public abstract int GetFoeState();

	public abstract int GetFoeStateTime();

	public abstract int GetFoeLevel();

	public abstract void Equip(string itemDescription);

	public abstract void EquipLeft(string itemDescription);

	public abstract void EquipRight(string itemDescription);

	public abstract void EquipFaerie(string itemDescription);

	public abstract void EquipLoadout(int loadoutNumber);

	public abstract void ActivateAbility(string abilityId);

	public abstract void EnableGameElement(string elementId);

	public abstract void DisableGameElement(string elementId);

	public abstract void PlaySound(string sfxId);

	public abstract void Brew(string ingredients);

	public abstract string GetFacialExpression();

	public abstract bool IsStartEvent();

	public abstract void SetStartEvent(bool start = true);

	public abstract bool IsLoopEvent();

	public abstract void SetLoopEvent(bool loop = true);

	public abstract bool IsAiEnabled();

	public abstract bool IsAiPaused();

	public abstract bool IsAiIdle();

	public abstract bool IsAiWalking();

	public abstract bool IsBigHead();

	public abstract int GetResourceStone();

	public abstract int GetResourceWood();

	public abstract int GetResourceTar();

	public abstract int GetResourceKi();

	public abstract int GetResourceBronze();

	public abstract int GetKiCrystalCount();

	public abstract int GetPlayerDirection();

	public abstract string GetPlayerName();

	public abstract object ShowPlayerScaredFace(List<object> parameters, InvocationContext ctx);

	public abstract int GetTotalGearPoints();

	public abstract string GetKeyInput();

	public abstract int GetScreenIndex();

	public abstract int GetScreenPosX();

	public abstract int GetScreenWidth();

	public abstract int GetScreenHeight();

	public abstract object FromScreenToWorldX(List<object> parameters, InvocationContext ctx);

	public abstract object FromScreenToWorldZ(List<object> parameters, InvocationContext ctx);

	public abstract object FromWorldToScreenX(List<object> parameters, InvocationContext ctx);

	public abstract object FromWorldToScreenZ(List<object> parameters, InvocationContext ctx);

	public abstract object MoveCameraToNextScreen(List<object> parameters, InvocationContext ctx);

	public abstract object MoveCameraToPreviousScreen(List<object> parameters, InvocationContext ctx);

	public abstract object ResetCameraScreenOffset(List<object> parameters, InvocationContext ctx);

	public abstract int GetRandom();

	public abstract int GetCursorX();

	public abstract int GetCursorY();

	public abstract object ClearScreen(List<object> parameters, InvocationContext ctx);

	public abstract object DrawHero(List<object> parameters, InvocationContext ctx);

	public abstract object DrawBackground(List<object> parameters, InvocationContext ctx);

	public abstract object DrawGetSymbol(List<object> parameters, InvocationContext ctx);

	public abstract object DrawBox(List<object> parameters, InvocationContext ctx);

	public abstract object LeaveLocation(List<object> parameters, InvocationContext ctx);

	public abstract object PauseLocation(List<object> parameters, InvocationContext ctx);

	public abstract object StorageGet(List<object> parameters, InvocationContext ctx);

	public abstract object StorageSet(List<object> parameters, InvocationContext ctx);

	public abstract object StorageExists(List<object> parameters, InvocationContext ctx);

	public abstract object StorageDelete(List<object> parameters, InvocationContext ctx);

	public abstract object StorageIncr(List<object> parameters, InvocationContext ctx);

	public abstract object StorageKeys(List<object> parameters, InvocationContext ctx);

	public abstract object ItemCanActivate(List<object> parameters, InvocationContext ctx);

	public abstract object ItemGetCooldown(List<object> parameters, InvocationContext ctx);

	public abstract object ItemGetCount(List<object> parameters, InvocationContext ctx);

	public abstract object ItemGetTreasureCount(List<object> parameters, InvocationContext ctx);

	public abstract object ItemGetTreasureLimit(List<object> parameters, InvocationContext ctx);

	public abstract object ItemGetPotion();

	public abstract object ItemGetLeft();

	public abstract object ItemGetRight();

	public abstract string ItemGetLeftId();

	public abstract string ItemGetRightId();

	public abstract int ItemGetLeftState();

	public abstract int ItemGetRightState();

	public abstract int ItemGetLeftTime();

	public abstract int ItemGetRightTime();

	public abstract object LoadoutGetLeft(List<object> parameters, InvocationContext ctx);

	public abstract object LoadoutGetRight(List<object> parameters, InvocationContext ctx);

	public abstract object SummonGetCount();

	public abstract object SummonGetId(List<object> parameters, InvocationContext ctx);

	public abstract object SummonGetName(List<object> parameters, InvocationContext ctx);

	public abstract object SummonGetVar(List<object> parameters, InvocationContext ctx);

	public abstract object SummonGetState(List<object> parameters, InvocationContext ctx);

	public abstract object SummonGetTime(List<object> parameters, InvocationContext ctx);
}
