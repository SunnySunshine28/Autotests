using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProject1.StepDefinitions.Api
{
    [Binding]
    public class UserAPISteps
    {
        private RestClient _client;
        private RestRequest _request;
        private RestResponse _response;

        [Given(@"Я создаю запрос для эндпоинта ""(.*)""")]
        public void GivenCreateRequest(string endpoint)
        {
            _client = new RestClient(endpoint);
        }

        [When(@"Я отправляю GET запрос")]
        public void WhenSendGetRequest()
        {
            _request = new RestRequest("", Method.Get);
            _response = _client.Execute(_request);
        }

        [When(@"Я отправляю POST запрос с телом:")]
        public void WhenSendPostRequestWithBody(string body)
        {
            _request = new RestRequest("", Method.Post);
            _request.AddStringBody(body, ContentType.Json);
            _response = _client.Execute(_request);
        }

        [Then(@"Статус код ответа должен быть (\d+)")]
        public void ThenCheckStatusCode(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)_response.StatusCode);
        }

        [Then(@"В ответе должно быть поле ""(.*)"" со значением ""(.*)""")]
        public void ThenCheckResponseField(string field, string expectedValue)
        {
            var json = JObject.Parse(_response.Content);
            Assert.AreEqual(expectedValue, json[field]?.ToString());
        }

        [Then(@"В ответе есть поле ""(.*)""")]
        public void ThenCheckFieldExists(string field)
        {
            var json = JObject.Parse(_response.Content);
            Assert.IsTrue(json.ContainsKey(field), $"Поле {field} отсутствует в ответе");
        }
    }
}
