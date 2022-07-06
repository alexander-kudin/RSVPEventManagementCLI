using System;
using System.Collections;

namespace ProjectFall2020
{
    class RSVPManager
    {
        private static int currentRSVPId;
        private ArrayList RSVPList = new ArrayList();

        public RSVPManager(int idSeed)
        {
            currentRSVPId = idSeed;
        }

        //MODIFICATION (ALEKSANDR KUDIN) – IMPLEMENTED METHODS: addRSVP().

        public void addRSVP(Customer customerRef, Event eventRef)
        {
            RSVP temp = new RSVP(currentRSVPId, customerRef, eventRef);
            RSVPList.Add(temp);
            currentRSVPId++;
        }

        //MODIFICATION (ALEKSANDR KUDIN) – IMPLEMENTED METHODS: RSVPExists().

        public bool RSVPExists(int RSVPId)
        {
            for (int i = 0; i < RSVPList.Count; i++)
            {
                RSVP temp = (RSVP)RSVPList[i];
                if (temp.getRSVPId() == RSVPId)
                {
                    return true;
                }
            }
            return false;
        }

        //MODIFICATION (ALEKSANDR KUDIN) – IMPLEMENTED METHODS: findRSVP().

        private int findRSVP(int RSVPId)
        {
            for (int i = 0; i < RSVPList.Count; i++)
            {
                RSVP temp = (RSVP)RSVPList[i];
                if (temp.getRSVPId() == RSVPId)
                    return i;
            }
            return -1;
        }

        //MODIFICATION (ALEKSANDR KUDIN) – IMPLEMENTED METHODS: getRSVP().

        public RSVP getRSVP(int RSVPId)
        {
            int loc = findRSVP(RSVPId);
            if (loc == -1) { return null; }
            return (RSVP)RSVPList[loc];
        }

        //MODIFICATION (ALEKSANDR KUDIN) – IMPLEMENTED METHODS: deleteRSVP().

        public bool deleteRSVP(int RSVPId)
        {
            int loc = findRSVP(RSVPId);
            if (loc == -1) { return false; }
            RSVPList.RemoveAt(loc);
            return true;
        }

        //MODIFICATION (MAKSIM KULIKOV) – IMPLEMENTED METHODS: getRSVPList().

        public string getRSVPList()
        {
            string s = "RSVP List:\n\n";

            foreach (RSVP RSVP in RSVPList)
            {
                s += RSVP.ToString() + "\n";
            }

            return s;
        }

        //MODIFICATION (SERGEY PAVLOV) – IMPLEMENTED METHODS: removeAllCustomerRSVP().

        public void removeAllCustomerRSVP(int cid) // removing all customer's RSVPs (removing from the array backwards).
        {
            for (int i = RSVPList.Count - 1; i >= 0; i--)
            {
                RSVP temp = (RSVP)RSVPList[i];
                if (temp.getCustomerRef().getId() == cid)
                {
                    RSVPList.RemoveAt(i);
                }
            }
        }
    }
}
