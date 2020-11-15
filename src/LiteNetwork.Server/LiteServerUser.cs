﻿using LiteNetwork.Common;
using LiteNetwork.Protocol.Abstractions;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LiteNetwork.Server
{
    public class LiteServerUser : ILiteConnection
    {
        private bool _disposed = false;

        public Guid Id { get; } = Guid.NewGuid();

        internal Socket Socket { get; set; }

        internal Action<ILitePacketStream> SendAction { get; set; }

        public virtual Task HandleMessageAsync(ILitePacketStream incomingPacketStream)
        {
            return Task.CompletedTask;
        }

        public void Send(ILitePacketStream packet) => SendAction?.Invoke(packet);

        public virtual void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                Socket.Dispose();
                Socket = null;
            }
        }
    }
}