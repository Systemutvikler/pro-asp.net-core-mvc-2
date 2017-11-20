using System.Collections.Generic;

namespace PartyInvites.Models
{
    public class Repository : IRepository
    {
        private List<GuestResponse> responses = new List<GuestResponse>();

        public IEnumerable<GuestResponse> Responses
        {
            get
            {
                return responses;
            }
        }

        public void AddResponse(GuestResponse response)
        {
            responses.Add(response);
        }
    }
}
