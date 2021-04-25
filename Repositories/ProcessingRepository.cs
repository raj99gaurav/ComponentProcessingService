﻿using ComponentProcessingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComponentProcessingService.Repositories
{
    public class ProcessingRepository: IProcessingRepository
    {
        public List<ProcessRequest> requests;
        public List<ProcessResponse> responses;
        public List<CardDetails> cardDetails;

        public ProcessingRepository()
        {
            DefectiveComponentDetail detail = new DefectiveComponentDetail();
            detail.ComponentName = "cell Phone";
            detail.ComponentType = "Accessory";
            detail.Qunatity = 1;
            requests = new List<ProcessRequest>()
            {
                new ProcessRequest{
                    Name="Ram",
                    ConactNumber="9876541230",
                    CreditCardNumber="9874 6544 9874 9654",
                    DefectiveComponent=detail,
                    IsPriorityRequest=false }
            };
            responses = new List<ProcessResponse>();
            cardDetails = new List<CardDetails>();
        }
        public IEnumerable<ProcessRequest> Get()
        {
            return requests;
        }
        public int GenerateId()
        {
            Random random = new Random();
            int temp = random.Next(10000, 99999);
            return temp;
        }
        public void AddRequest(ProcessRequest processRequest)
        {
            CardDetails card = new CardDetails();
            card.CreditCardNumber = processRequest.CreditCardNumber;
            card.Limit = 100000;
            cardDetails.Add(card);
            requests.Add(processRequest);
        }
        public void AddResponse(ProcessResponse processResponse)
        {
            responses.Add(processResponse);
        }
        public void UpdataBalance(string cardNumber, double newLimit)
        {
            CardDetails card = cardDetails.SingleOrDefault(c => c.CreditCardNumber == cardNumber);
            int index = cardDetails.IndexOf(card);
            cardDetails[index].Limit = newLimit;
        }
    }
}
