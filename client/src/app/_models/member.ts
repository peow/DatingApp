import { Photo } from './photo';

export interface Member {
    id: number;
    username: string;
    age: number;
    knownAs: string;
    created: Date;
    lastActive: Date;
    gender: string;
    introduction: string;
    lookingFor: string;
    interests: string;
    country: string;
    photoUrl: string;
    photos: Photo[];
  }