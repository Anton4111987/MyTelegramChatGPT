using OpenAI.ChatGpt;
using OpenAI.ChatGpt.Models.ChatCompletion.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MyTelegramChatGPT
{
    internal class ChatGPT
    {
        public async Task<string> Ask(string text)
        {
            string nameKey = "Key_API";
            string? key = Environment.GetEnvironmentVariable(nameKey);
            if(key==null)
            {
                throw new InvalidOperationException($"Переменная окружения {nameKey} не задана");
            }
            using var client = new OpenAiClient(key);
            
            string response = await client.GetChatCompletions(new UserMessage(text), maxTokens: 300);
            
            return response;
        }

    }

}
