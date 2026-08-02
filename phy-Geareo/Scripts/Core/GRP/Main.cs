using System;
using System.Collections.Generic;
using GRP.Net;
using Rhizomatic;
using Rhizomatic.Utility;
using UnityEngine;

namespace GRP
{
	public class Main : MonoBehaviour
	{
		public MainConfig config;

		public NavigatorView navigatorView;

		public ToasterView toasterView;

		public AudioView audioView;

		public List<ulong> ids;

		public GameSession gameSession;

		public Settings settings;

		public NavigatorViewable navigator;

		public ToasterViewable toaster;

		public AudioViewable audio;

		public NetManagerController netManager;

		public NetGame netGame;

		public Clipboard clipBoard;

		public Context context;

		public RealmLoader realmLoader;

		public Context currentDomainContext;

		public Domain currentDomain;

		public static Action<Main> onStart;

		public BuildResult buildResult => null;

		private void Start()
		{
		}

		private void OnSettingsChanged()
		{
		}

		private void Update()
		{
		}

		private void UnloadOtherScenes()
		{
		}

		public MainMenu LoadMainMenu()
		{
			return null;
		}

		public TDomain LoadDomain<TDomain>(DomainConfig config) where TDomain : Domain
		{
			return null;
		}

		public Domain LoadDomain(DomainConfig config)
		{
			return null;
		}

		public static Main Of(Context context)
		{
			return null;
		}
	}
}
