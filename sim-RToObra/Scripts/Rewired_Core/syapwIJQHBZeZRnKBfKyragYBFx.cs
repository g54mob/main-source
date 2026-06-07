using System.Collections.Generic;
using Rewired;

internal interface syapwIJQHBZeZRnKBfKyragYBFx
{
	ControllerMap this[int index] { get; }

	int Count { get; }

	IList<ControllerMap> Maps { get; }

	IEnumerable<ControllerMap> IterateMapsInCategory_ControllerMap(int P_0);

	IList<T> GetMaps<T>() where T : ControllerMap;

	void Add(ControllerMap P_0, BoolOption P_1);

	void Remove(ControllerMap P_0);

	void Remove(int P_0);

	void Remove(int P_0, int P_1);

	void RemoveById(int P_0);

	int IndexOf(int P_0);

	int IndexOf(int P_0, int P_1);

	bool Contains(int P_0);

	bool Contains(int P_0, int P_1);

	void Clear(bool P_0);

	void Clear(int P_0, bool P_1);

	void ClearByLayout(int P_0, bool P_1);

	int SetEnabledAll(bool P_0);

	int SetEnabledByCategory(bool P_0, int P_1);

	int SetEnabledByCategory(bool P_0, int P_1, int P_2);

	bool ContainsMapInCategory(int P_0);

	ControllerMap GetMap(int P_0);

	ControllerMap GetMap(int P_0, int P_1);

	ControllerMap[] GetMaps();

	ControllerMap GetMapByCategory(int P_0);

	ControllerMap[] GetMapsByCategory(int P_0);

	int GetMapsByCategory(int P_0, List<ControllerMap> P_1, bool P_2);

	int GetMapsByCategory<T>(int P_0, List<T> P_1, bool P_2) where T : ControllerMap;

	int GetMaps(List<ControllerMap> P_0, bool P_1);

	int GetMaps<T>(List<T> P_0, bool P_1) where T : ControllerMap;
}
