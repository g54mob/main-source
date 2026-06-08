public class ak
{
	public class soundengine
	{
		public class error
		{
			public const string invalid_playing_id = "ak.soundengine.invalid_playing_id";

			public const string wrong_volumeOffsets_length = "ak.soundengine.wrong_volumeOffsets_length";
		}

		public const string setMultiplePositions = "ak.soundengine.setMultiplePositions";

		public const string setScalingFactor = "ak.soundengine.setScalingFactor";

		public const string postEvent = "ak.soundengine.postEvent";

		public const string setRTPCValue = "ak.soundengine.setRTPCValue";

		public const string setObjectObstructionAndOcclusion = "ak.soundengine.setObjectObstructionAndOcclusion";

		public const string setListeners = "ak.soundengine.setListeners";

		public const string executeActionOnEvent = "ak.soundengine.executeActionOnEvent";

		public const string setListenerSpatialization = "ak.soundengine.setListenerSpatialization";

		public const string resetRTPCValue = "ak.soundengine.resetRTPCValue";

		public const string unregisterGameObj = "ak.soundengine.unregisterGameObj";

		public const string stopPlayingID = "ak.soundengine.stopPlayingID";

		public const string setGameObjectAuxSendValues = "ak.soundengine.setGameObjectAuxSendValues";

		public const string seekOnEvent = "ak.soundengine.seekOnEvent";

		public const string registerGameObj = "ak.soundengine.registerGameObj";

		public const string setDefaultListeners = "ak.soundengine.setDefaultListeners";

		public const string setPosition = "ak.soundengine.setPosition";

		public const string postMsgMonitor = "ak.soundengine.postMsgMonitor";

		public const string setGameObjectOutputBusVolume = "ak.soundengine.setGameObjectOutputBusVolume";

		public const string setSwitch = "ak.soundengine.setSwitch";

		public const string stopAll = "ak.soundengine.stopAll";

		public const string postTrigger = "ak.soundengine.postTrigger";
	}

	public class wwise
	{
		public class error
		{
			public const string invalid_arguments = "ak.wwise.invalid_arguments";

			public const string invalid_options = "ak.wwise.invalid_options";

			public const string invalid_json = "ak.wwise.invalid_json";

			public const string invalid_object = "ak.wwise.invalid_object";

			public const string invalid_property = "ak.wwise.invalid_property";

			public const string invalid_reference = "ak.wwise.invalid_reference";

			public const string invalid_query = "ak.wwise.query.invalid_query";

			public const string file_error = "ak.wwise.file_error";

			public const string unavailable = "ak.wwise.unavailable";

			public const string unexpected_error = "ak.wwise.unexpected_error";

			public const string locked = "ak.wwise.locked";

			public const string connection_failed = "ak.wwise.connection_failed";

			public const string already_connected = "ak.wwise.already_connected";

			public const string wwise_console = "ak.wwise.wwise_console";
		}

		public class debug
		{
			public const string testAssert = "ak.wwise.debug.testAssert";

			public const string assertFailed = "ak.wwise.debug.assertFailed";

			public const string enableAutomationMode = "ak.wwise.debug.enableAutomationMode";

			public const string enableAsserts = "ak.wwise.debug.enableAsserts";
		}

		public class core
		{
			public class audioSourcePeaks
			{
				public const string getMinMaxPeaksInRegion = "ak.wwise.core.audioSourcePeaks.getMinMaxPeaksInRegion";

				public const string getMinMaxPeaksInTrimmedRegion = "ak.wwise.core.audioSourcePeaks.getMinMaxPeaksInTrimmedRegion";
			}

			public class remote
			{
				public const string getConnectionStatus = "ak.wwise.core.remote.getConnectionStatus";

				public const string getAvailableConsoles = "ak.wwise.core.remote.getAvailableConsoles";

				public const string disconnect = "ak.wwise.core.remote.disconnect";

				public const string connect = "ak.wwise.core.remote.connect";
			}

			public class log
			{
				public const string itemAdded = "ak.wwise.core.log.itemAdded";

				public const string get = "ak.wwise.core.log.get";
			}

			public class @object
			{
				public const string referenceChanged = "ak.wwise.core.object.referenceChanged";

				public const string move = "ak.wwise.core.object.move";

				public const string attenuationCurveLinkChanged = "ak.wwise.core.object.attenuationCurveLinkChanged";

				public const string childAdded = "ak.wwise.core.object.childAdded";

				public const string getTypes = "ak.wwise.core.object.getTypes";

				public const string propertyChanged = "ak.wwise.core.object.propertyChanged";

				public const string create = "ak.wwise.core.object.create";

				public const string get = "ak.wwise.core.object.get";

				public const string preDeleted = "ak.wwise.core.object.preDeleted";

				public const string nameChanged = "ak.wwise.core.object.nameChanged";

				public const string postDeleted = "ak.wwise.core.object.postDeleted";

				public const string notesChanged = "ak.wwise.core.object.notesChanged";

				public const string getPropertyInfo = "ak.wwise.core.object.getPropertyInfo";

				public const string setName = "ak.wwise.core.object.setName";

				public const string setNotes = "ak.wwise.core.object.setNotes";

				public const string setAttenuationCurve = "ak.wwise.core.object.setAttenuationCurve";

				public const string setProperty = "ak.wwise.core.object.setProperty";

				public const string copy = "ak.wwise.core.object.copy";

				public const string isPropertyEnabled = "ak.wwise.core.object.isPropertyEnabled";

				public const string setRandomizer = "ak.wwise.core.object.setRandomizer";

				public const string setReference = "ak.wwise.core.object.setReference";

				public const string attenuationCurveChanged = "ak.wwise.core.object.attenuationCurveChanged";

				public const string created = "ak.wwise.core.object.created";

				public const string childRemoved = "ak.wwise.core.object.childRemoved";

				public const string getPropertyNames = "ak.wwise.core.object.getPropertyNames";

				public const string getAttenuationCurve = "ak.wwise.core.object.getAttenuationCurve";

				public const string curveChanged = "ak.wwise.core.object.curveChanged";

				public const string delete = "ak.wwise.core.object.delete";

				public const string getPropertyAndReferenceNames = "ak.wwise.core.object.getPropertyAndReferenceNames";
			}

			public class undo
			{
				public const string endGroup = "ak.wwise.core.undo.endGroup";

				public const string cancelGroup = "ak.wwise.core.undo.cancelGroup";

				public const string beginGroup = "ak.wwise.core.undo.beginGroup";
			}

			public class profiler
			{
				public const string getCursorTime = "ak.wwise.core.profiler.getCursorTime";

				public const string startCapture = "ak.wwise.core.profiler.startCapture";

				public const string getVoiceContributions = "ak.wwise.core.profiler.getVoiceContributions";

				public const string getVoices = "ak.wwise.core.profiler.getVoices";

				public const string getBusses = "ak.wwise.core.profiler.getBusses";

				public const string stopCapture = "ak.wwise.core.profiler.stopCapture";
			}

			public class project
			{
				public const string postClosed = "ak.wwise.core.project.postClosed";

				public const string loaded = "ak.wwise.core.project.loaded";

				public const string preClosed = "ak.wwise.core.project.preClosed";

				public const string save = "ak.wwise.core.project.save";

				public const string saved = "ak.wwise.core.project.saved";
			}

			public class transport
			{
				public const string getState = "ak.wwise.core.transport.getState";

				public const string stateChanged = "ak.wwise.core.transport.stateChanged";

				public const string create = "ak.wwise.core.transport.create";

				public const string getList = "ak.wwise.core.transport.getList";

				public const string destroy = "ak.wwise.core.transport.destroy";

				public const string executeAction = "ak.wwise.core.transport.executeAction";
			}

			public class soundbank
			{
				public const string getInclusions = "ak.wwise.core.soundbank.getInclusions";

				public const string generated = "ak.wwise.core.soundbank.generated";

				public const string setInclusions = "ak.wwise.core.soundbank.setInclusions";
			}

			public class audio
			{
				public const string import = "ak.wwise.core.audio.import";

				public const string importTabDelimited = "ak.wwise.core.audio.importTabDelimited";

				public const string imported = "ak.wwise.core.audio.imported";
			}

			public class switchContainer
			{
				public const string removeAssignment = "ak.wwise.core.switchContainer.removeAssignment";

				public const string getAssignments = "ak.wwise.core.switchContainer.getAssignments";

				public const string assignmentRemoved = "ak.wwise.core.switchContainer.assignmentRemoved";

				public const string addAssignment = "ak.wwise.core.switchContainer.addAssignment";

				public const string assignmentAdded = "ak.wwise.core.switchContainer.assignmentAdded";
			}

			public class plugin
			{
				public const string getList = "ak.wwise.core.plugin.getList";

				public const string getProperty = "ak.wwise.core.plugin.getProperty";

				public const string getProperties = "ak.wwise.core.plugin.getProperties";
			}

			public const string getInfo = "ak.wwise.core.getInfo";
		}

		public class ui
		{
			public class project
			{
				public const string close = "ak.wwise.ui.project.close";

				public const string open = "ak.wwise.ui.project.open";
			}

			public class commands
			{
				public const string unregister = "ak.wwise.ui.commands.unregister";

				public const string executed = "ak.wwise.ui.commands.executed";

				public const string execute = "ak.wwise.ui.commands.execute";

				public const string register = "ak.wwise.ui.commands.register";

				public const string getCommands = "ak.wwise.ui.commands.getCommands";
			}

			public const string bringToForeground = "ak.wwise.ui.bringToForeground";

			public const string getSelectedObjects = "ak.wwise.ui.getSelectedObjects";

			public const string selectionChanged = "ak.wwise.ui.selectionChanged";
		}

		public class waapi
		{
			public const string getTopics = "ak.wwise.waapi.getTopics";

			public const string getFunctions = "ak.wwise.waapi.getFunctions";

			public const string getSchema = "ak.wwise.waapi.getSchema";
		}
	}
}
