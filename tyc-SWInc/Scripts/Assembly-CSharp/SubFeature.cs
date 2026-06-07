using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SINetworking;
using StatementParser;
using Tyd;
using UnityEngine;

[Serializable]
public class SubFeature : FeatureBase
{
	public enum NetworkRun
	{
		Local = 0,
		Host = 1,
		Everyone = 2
	}

	private readonly int _level;

	public readonly NetworkRun RunType;

	private Dictionary<ScriptSystem.EntryPoint, string> _scripts;

	[NonSerialized]
	private Dictionary<ScriptSystem.EntryPoint, LineParse.TreeNode> _compiled;

	[NonSerialized]
	private bool _hasCompiled;

	[NonSerialized]
	private bool _disableScript;

	private bool _networkFixed;

	private static Regex _bugsFix = new Regex("Product\\.Bugs\\W*=\\W*([^\\;]+)");

	private static Regex _bugsFix2 = new Regex("\\bProduct\\.Bugs\\b");

	private static Regex _userBaseFix = new Regex("Product\\.Userbase\\W*=\\W*([^\\;]+)");

	public override int Level
	{
		get
		{
			return _level;
		}
	}

	public void RunScript(ScriptSystem.EntryPoint entry, ScriptSystem.DefaultScope world, SoftwareProduct product)
	{
		Compile(false);
		LineParse.TreeNode value;
		if (_disableScript || !_compiled.TryGetValue(entry, out value))
		{
			return;
		}
		NetworkRun networkRun = RunType;
		byte b = 0;
		if (NetworkManager.IsConnected && (entry & ScriptSystem.EntryPoint.ValidForMultiplayer) > ScriptSystem.EntryPoint.None)
		{
			switch (networkRun)
			{
			case NetworkRun.Local:
				if (!product.DevCompany.IsLocalPlayer)
				{
					networkRun = NetworkRun.Host;
					b = product.DevCompany.NetworkPlayerID;
					if (NetworkManager.GetPlayer(b) == null)
					{
						return;
					}
				}
				break;
			case NetworkRun.Host:
				if (!NetworkManager.IsHost)
				{
					b = NetworkManager.Instance.HostPlayer.ID;
				}
				else
				{
					networkRun = NetworkRun.Local;
				}
				break;
			}
		}
		else
		{
			networkRun = NetworkRun.Local;
		}
		if (networkRun == NetworkRun.Local || networkRun == NetworkRun.Everyone)
		{
			ActuallyRunScript(value, world);
		}
		if (networkRun == NetworkRun.Host || networkRun == NetworkRun.Everyone)
		{
			ScriptSystem.ProductScope scope;
			ScriptSystem.CopyScope scope2;
			if ((scope = world as ScriptSystem.ProductScope) != null)
			{
				NetworkMessaging.SendRunProductScripts(product.ID, ID, entry, scope, (networkRun != NetworkRun.Host) ? NetworkMessaging.MessageTarget.EveryoneButMe : NetworkMessaging.MessageTarget.Specifically, b);
			}
			else if ((scope2 = world as ScriptSystem.CopyScope) != null)
			{
				NetworkMessaging.SendRunCopyScripts(product.ID, ID, entry, scope2, (networkRun != NetworkRun.Host) ? NetworkMessaging.MessageTarget.EveryoneButMe : NetworkMessaging.MessageTarget.Specifically, b);
			}
		}
	}

	public void ActuallyRunScript(ScriptSystem.EntryPoint entry, ScriptSystem.DefaultScope world)
	{
		Compile(false);
		LineParse.TreeNode value;
		if (!_disableScript && _compiled.TryGetValue(entry, out value))
		{
			ActuallyRunScript(value, world);
		}
	}

	public void ActuallyRunScript(LineParse.TreeNode code, ScriptSystem.DefaultScope world)
	{
		try
		{
			NetworkMeta.CheckDirty();
			LineParse.Execute(code, world);
		}
		catch (Exception ex)
		{
			_disableScript = true;
			SoftwareType orDefault = MarketSimulation.Active.SoftwareTypes.GetOrDefault(Software);
			ModErrorWindow.Show((orDefault != null) ? orDefault.ModName : null, new Exception("Error when running script for feature " + Name + " in software " + Software + ": " + ex.Message));
		}
	}

	public ScriptSystem.EntryPoint GetEntryPoints()
	{
		ScriptSystem.EntryPoint entryPoint = ScriptSystem.EntryPoint.None;
		foreach (KeyValuePair<ScriptSystem.EntryPoint, string> script in _scripts)
		{
			entryPoint |= script.Key;
		}
		return entryPoint;
	}

	private static LineParse.ScriptWorld GetWorld(ScriptSystem.EntryPoint p)
	{
		switch (p)
		{
		case ScriptSystem.EntryPoint.EndOfDay:
		case ScriptSystem.EntryPoint.OnRelease:
			return ScriptSystem.ProductScope.GetTempScope(null, default(SDateTime), true);
		case ScriptSystem.EntryPoint.AfterSales:
			return new ScriptSystem.SaleScope();
		case ScriptSystem.EntryPoint.NewCopies:
			return ScriptSystem.CopyScope.GetTempScope(null, 0u, true);
		case ScriptSystem.EntryPoint.WorkItemChange:
			return ScriptSystem.DevScope.GetTempScope(null, false, false, true);
		default:
			return null;
		}
	}

	private void Compile(bool throwError)
	{
		if (_disableScript || _hasCompiled)
		{
			return;
		}
		if (_scripts != null)
		{
			if (!_networkFixed)
			{
				_scripts = _scripts.ToDictionary((KeyValuePair<ScriptSystem.EntryPoint, string> x) => x.Key, (KeyValuePair<ScriptSystem.EntryPoint, string> x) => FixNetworkChanges(x.Value, x.Key));
				_networkFixed = true;
			}
			_compiled = new Dictionary<ScriptSystem.EntryPoint, LineParse.TreeNode>();
			foreach (KeyValuePair<ScriptSystem.EntryPoint, string> script in _scripts)
			{
				try
				{
					LineParse.TreeNode treeNode = LineParse.Parse(script.Value);
					LineParse.GetType(treeNode, GetWorld(script.Key));
					_compiled.Add(script.Key, treeNode);
				}
				catch (Exception ex)
				{
					_disableScript = true;
					Exception ex2 = new Exception(string.Concat("Error compiling ", script.Key, " script for feature ", Name, " in software ", Software, ": ", ex.Message));
					if (throwError)
					{
						throw ex2;
					}
					Debug.LogException(ex2);
					break;
				}
			}
		}
		_hasCompiled = true;
	}

	public string FixNetworkChanges(string script, ScriptSystem.EntryPoint entry)
	{
		if ((entry & ScriptSystem.EntryPoint.ValidForMultiplayer) > ScriptSystem.EntryPoint.None)
		{
			script = _bugsFix.Replace(script, "Product.ChangeBugs(Product.StartBugss, $1)");
			script = _bugsFix2.Replace(script, "Product.Bugss");
			script = _userBaseFix.Replace(script, "Product.ChangeUserbase($1)");
		}
		return script;
	}

	public SubFeature()
	{
	}

	public SubFeature(SubFeature feat)
		: base(feat)
	{
		_level = feat.Level;
		if (_level == 3)
		{
			_scripts = feat._scripts;
			_hasCompiled = feat._hasCompiled;
			_compiled = feat._compiled;
			RunType = feat.RunType;
			_networkFixed = feat._networkFixed;
		}
	}

	public SubFeature(TydCollection node, FeatureBase parent, string software, string pathRoot)
		: base(node, parent.Spec, software, parent.Unlock, parent.SoftwareCategories)
	{
		try
		{
			_level = node.GetChildValue("Level", true, 0);
			RunType = node.GetChildValue("RunType", false, NetworkRun.Local);
			if (_level < 1 || _level > 3)
			{
				throw new Exception("Feature level has to be between 1 and 3, inclusive");
			}
			if (_level == 3)
			{
				Dictionary<ScriptSystem.EntryPoint, string> dictionary = new Dictionary<ScriptSystem.EntryPoint, string>();
				for (int i = 0; i < node.Nodes.Count; i++)
				{
					TydString tydString;
					if ((tydString = node.Nodes[i] as TydString) != null && tydString.Name.StartsWith("Script_"))
					{
						ScriptSystem.EntryPoint entryPoint = tydString.Name.Substring(tydString.Name.IndexOf('_') + 1).ToEnum<ScriptSystem.EntryPoint>();
						dictionary[entryPoint] = ((pathRoot == null) ? tydString.Value : FixNetworkChanges(GetScript(tydString.Value, pathRoot), entryPoint));
					}
				}
				_scripts = dictionary;
				Compile(true);
			}
			_networkFixed = true;
		}
		catch (Exception ex)
		{
			throw new Exception("Error loading feature " + Name + ": " + ex.Message);
		}
	}

	private static string GetScript(string s, string path)
	{
		if (s.Length > 0 && s[0] == '/')
		{
			return Utilities.ReadOnlyReadAllText(Path.Combine(path, s.Substring(1)));
		}
		return s;
	}
}
