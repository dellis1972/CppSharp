﻿using System;

namespace CppSharp
{
    public enum DiagnosticId
    {
        AmbiguousOverload,
        InvalidOperatorOverload,
        SymbolNotFound,
        FileGenerated,
    }

    public enum DiagnosticKind
    {
        Message,
        Warning,
        Error
    }

    public struct DiagnosticInfo
    {
        public DiagnosticKind Kind;
        public string Message;
        public string File;
        public int Line;
        public int Column;
    }

    public interface IDiagnosticConsumer
    {
        void Emit(DiagnosticInfo info);
    }

    public static class DiagnosticExtensions
    {
        public static void EmitMessage(this IDiagnosticConsumer consumer,
            DiagnosticId id, string msg, params object[] args)
        {
            var diagInfo = new DiagnosticInfo
                {
                    Kind = DiagnosticKind.Message,
                    Message = string.Format(msg, args)
                };

            consumer.Emit(diagInfo);
        }

        public static void EmitWarning(this IDiagnosticConsumer consumer,
            DiagnosticId id, string msg, params object[] args)
        {
            var diagInfo = new DiagnosticInfo
            {
                Kind = DiagnosticKind.Warning,
                Message = string.Format(msg, args)
            };

            consumer.Emit(diagInfo);
        }

        public static void EmitError(this IDiagnosticConsumer consumer,
            DiagnosticId id, string msg, params object[] args)
        {
            var diagInfo = new DiagnosticInfo
            {
                Kind = DiagnosticKind.Error,
                Message = string.Format(msg, args)
            };

            consumer.Emit(diagInfo);
        }
    }

    public class TextDiagnosticPrinter : IDiagnosticConsumer
    {
        public void Emit(DiagnosticInfo info)
        {
            Console.WriteLine(info.Message);
        }
    }
}
