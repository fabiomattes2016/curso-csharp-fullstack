import { Evento } from '../interfaces/Evento';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EventoService {
  baseUrl = 'http://localhost:5000/api/v1';

  constructor(private http: HttpClient) {}

  getAllEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseUrl}/evento`);
  }

  getEventoByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseUrl}/evento/getByTema${tema}`);
  }

  getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseUrl}/evento/${id}`);
  }

  postEvento(evento: Evento) {
    return this.http.post<Evento>(`${this.baseUrl}/evento`, evento);
  }

  putEvento(evento: Evento) {
    return this.http.put<Evento>(`${this.baseUrl}/evento/${evento.id}`, evento);
  }

  deleteEvento(id: number) {
    return this.http.delete<Evento>(`${this.baseUrl}/evento/${id}`);
  }
}
