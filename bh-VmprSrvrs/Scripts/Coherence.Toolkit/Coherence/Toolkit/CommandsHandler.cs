using System;
using System.Collections.Generic;
using System.ComponentModel;
using Coherence.Entities;
using Coherence.Log;
using Coherence.ProtocolDef;
using Coherence.Toolkit.Bindings;
using UnityEngine;

namespace Coherence.Toolkit
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CommandsHandler
	{
		private struct CommandData
		{
			public UnityEngine.Component Receiver;

			public GenericCommandRequestDelegate Receive;

			public GenericCommandRequestDelegate Send;

			public MessageTarget Routing;

			public bool HasSenderArg;
		}

		private struct SendOptions
		{
			public UnityEngine.Component Receiver;

			public bool SendToAllBindings;
		}

		[Flags]
		private enum SendTo
		{
			None = 0,
			Self = 1,
			Others = 2,
			All = 3
		}

		private readonly ICoherenceSync sync;

		private readonly List<Binding> bindings;

		private readonly Dictionary<string, List<CommandData>> commandRequestDataByName;

		private readonly Dictionary<string, List<CommandBinding>> commandNameMemoization;

		private readonly HashSet<string> registeredCommandNames;

		private CoherenceSyncBaked BakedScript => null;

		private bool HasStateAuthority => false;

		private Entity EntityID => default(Entity);

		private ICoherenceBridge CoherenceBridge => null;

		private CoherenceClientConnection MyConnection => null;

		private string Name => null;

		private bool IsConnected => false;

		public Coherence.Log.Logger logger { get; internal set; }

		public CommandsHandler(ICoherenceSync sync, List<Binding> bindings, Coherence.Log.Logger logger)
		{
		}

		public void AddBakedCommand(string name, string signatureAsString, GenericCommandRequestDelegate sendDelegate, GenericCommandRequestDelegate receiveDelegate, MessageTarget routing, UnityEngine.Component receiver, bool hasSenderArg)
		{
		}

		public void HandleCommand(IEntityCommand command, MessageTarget target)
		{
		}

		public void HandleGenericCommand(string commandGuid, MessageTarget target, byte[] data, Entity[] entityIDs)
		{
		}

		public bool SendCommand(Type targetType, string methodName, MessageTarget target, ChannelID channelID, bool sendToAllBindings, params object[] args)
		{
			return false;
		}

		public bool SendCommand(Type targetType, string methodName, MessageTarget target, ChannelID channelID, bool sendToAllBindings, params (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommand(Action method, MessageTarget target, ChannelID channelID)
		{
			return false;
		}

		public bool SendCommand<T>(Action<T> method, MessageTarget target, ChannelID channelID, (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommand<T1, T2>(Action<T1, T2> method, MessageTarget target, ChannelID channelID, (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3>(Action<T1, T2, T3> method, MessageTarget target, ChannelID channelID, (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4>(Action<T1, T2, T3, T4> method, MessageTarget target, ChannelID channelID, (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> method, MessageTarget target, ChannelID channelID, (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> method, MessageTarget target, ChannelID channelID, (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> method, MessageTarget target, ChannelID channelID, (Type, object)[] args)
		{
			return false;
		}

		public bool SendCommand<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> method, MessageTarget target, ChannelID channelID, (Type, object)[] args)
		{
			return false;
		}

		private SendOptions GetSendOptions(UnityEngine.Component receiver, bool sendToAllBindings)
		{
			return default(SendOptions);
		}

		private bool ExecuteSendCommand(MessageTarget target, ChannelID channelID, bool sendToAllBindings, (Type, object)[] args, object receiver, string methodName)
		{
			return false;
		}

		private bool GetCommandNameAndValidateEntityId(Type targetType, string methodName, out string commandName)
		{
			commandName = null;
			return false;
		}

		private (object[], Type[], bool) ProcessArgs(object[] args)
		{
			return default((object[], Type[], bool));
		}

		private bool SendCommandUsingBakedScript(string commandName, MessageTarget target, ChannelID channelID, SendOptions options, params (Type, object)[] args)
		{
			return false;
		}

		private bool SendCommandUsingBakedScript(string commandName, MessageTarget target, ChannelID channelID, SendOptions options, params object[] args)
		{
			return false;
		}

		private bool SendCommandUsingBakedScript(string commandName, MessageTarget target, ChannelID channelID, SendOptions options, object[] args, Type[] types)
		{
			return false;
		}

		private object[] UnifyNullTypes(object[] args, Type[] types)
		{
			return null;
		}

		private SendTo WhoToSendTo(MessageTarget target)
		{
			return default(SendTo);
		}

		private bool ValidateNumberOfCommands(string commandName, bool sendToAllBindings, List<CommandData> commands)
		{
			return false;
		}

		private bool ValidateBakedCommandSending(string command, Type[] argsToValidate, MessageTarget messageTarget, SendOptions options, out List<CommandData> data)
		{
			data = null;
			return false;
		}

		private bool ValidateOrphan(string commandName, MessageTarget target)
		{
			return false;
		}

		private bool ValidateEntityArgumentsAreInitialized(string command, object[] args, Type[] argTypes)
		{
			return false;
		}

		private bool ValidateArgumentTypes(string command, object[] args, Type[] argTypes)
		{
			return false;
		}

		private string GetMessageForInvalidCommand(string command, Type[] argsToValidate)
		{
			return null;
		}

		private bool CommandNameHasBinding(string commandName)
		{
			return false;
		}

		private List<CommandBinding> GetCommandBindingsMemoized(string commandName)
		{
			return null;
		}

		private static bool CanRouteMessage(MessageTarget target, MessageTarget routing)
		{
			return false;
		}
	}
}
