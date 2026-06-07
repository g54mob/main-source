using Newtonsoft.Json;
using UnityEngine;

public class Cathub
{
	public CathubScheme[] schemes = new CathubScheme[4]
	{
		new CathubScheme(),
		new CathubScheme(),
		new CathubScheme(),
		new CathubScheme()
	};

	public int currScheme;

	public int useAsCustomScheme;

	private History history = new History();

	public void RecordHistory()
	{
		history.AddRecord();
	}

	public bool LoadHistory(string filename)
	{
		return history.Load(filename);
	}

	public void ClearHistory(string newQuest = "")
	{
		history.Clear(newQuest);
	}

	public void RewriteLastRecord()
	{
		history.RewriteLastRecord();
	}

	public bool UndoHistory()
	{
		return history.Undo();
	}

	public bool RedoHistory()
	{
		return history.Redo();
	}

	public bool isUndoAvialble()
	{
		return history.isUndoAvialble();
	}

	public bool isRedoAviable()
	{
		return history.isRedoAviable();
	}

	public bool RedoReplayHistory()
	{
		return history.Redo(writeReplay: false);
	}

	public bool SetScheme(int i, CathubScheme scheme)
	{
		if (i < GetNumSchemes())
		{
			currScheme = i;
			schemes[i] = scheme;
			Transform transform = Logic.GetModel().construction.algoBlock.transform;
			schemes[i].zoom = transform.localScale;
			schemes[i].penPosition = transform.position;
			schemes[i].pivot = transform.GetComponent<RectTransform>().pivot;
			return true;
		}
		return false;
	}

	public void SetCurrentScheme(int id)
	{
		currScheme = id;
	}

	public void Clear()
	{
		currScheme = 0;
		useAsCustomScheme = 0;
	}

	public int GetNumSchemes()
	{
		return schemes.Length;
	}

	public void SetUseAsCustom(int id)
	{
		useAsCustomScheme = id;
	}

	public int GetUseAsCustom()
	{
		return useAsCustomScheme;
	}

	public int GetCurrentScheme()
	{
		return currScheme;
	}

	public CathubScheme GetCurCathubScheme()
	{
		return schemes[currScheme];
	}

	public CathubScheme GetScheme(int i)
	{
		if (i >= GetNumSchemes())
		{
			return null;
		}
		return schemes[i];
	}

	public SchemeBlock GetLastOpenScheme()
	{
		return GetSchemeBlock(currScheme);
	}

	public SchemeBlock GetCustomScheme()
	{
		return GetSchemeBlock(useAsCustomScheme);
	}

	public SchemeBlock GetSchemeBlock(int index)
	{
		if (GetNumSchemes() == 0 || GetNumSchemes() <= index)
		{
			return null;
		}
		return DeserializeObject<SchemeBlock>(schemes[index].json);
	}

	public int GetNumValidSchemes()
	{
		int num = 0;
		CathubScheme[] array = schemes;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].IsValid())
			{
				num++;
			}
		}
		return num;
	}

	public SchemeBlock SchemeToSchemeBlock(int index)
	{
		CathubScheme scheme = GetScheme(index);
		if (scheme == null)
		{
			return null;
		}
		return DeserializeObject<SchemeBlock>(scheme.json);
	}

	public T DeserializeObject<T>(string json)
	{
		return JsonConvert.DeserializeObject<T>(json, Logic.GetGlobalSettings());
	}
}
